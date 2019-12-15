using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField]private float velocidadePadrao, raioRC, distCentro;
    private float velocidade;
    public int index;
    [Range(0,2)]
    public float typeVel;
    private Transform particula;
    private Animator _animator;
    private Rigidbody2D rbPlayer;
    private bool anguloDireita, anguloRaycast, colidiu, colidiuFrente;
    private RaycastHit2D[] colididosFrente;
    Collider2D[] colididos;
    private string botaoPrincipal;
    [SerializeField] private LayerMask lm;
    private Vector3 soma;
    private Ray r;

    bool podeJogar = false;
    void Start()
    {
        particula = transform.GetChild(0).GetChild(0);
        botaoPrincipal = TelaSelecao.teclasEscolhidas[index];
        rbPlayer = GetComponent<Rigidbody2D>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        if (typeVel == 0) velocidade = (velocidadePadrao + (UnityEngine.Camera.main.transform.position.x - this.transform.position.x) * 0.15f);
        else if (typeVel == 1) velocidade = (velocidadePadrao * 2f);
        else if (typeVel == 2) velocidade = (velocidadePadrao / 2f);
        colididosFrente = Physics2D.RaycastAll(this.transform.position, Vector2.right, 0.6f, lm);
        colidiu = colididosFrente.Length > 1;
        if (colidiu)
        {
            rbPlayer.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rbPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = anguloRaycast;
        particula.localPosition = new Vector3(particula.localPosition.x, (anguloRaycast ? 0.12f : -0.12f), particula.localPosition.z);
        Movimento();
        _animator.SetFloat("Velocidade", rbPlayer.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("PodeJogar");
        }
        if (GameController.quantidadeNavios == 1)
        {
            GameController.SpriteVencedor = this.gameObject.GetComponent<Sprite>();
        }
    }
    private void Movimento()
    {
        if (podeJogar)
        {
            rbPlayer.velocity = new Vector3((colidiuFrente ? 0 : velocidade), rbPlayer.velocity.y);
        }
        soma.y = (anguloRaycast) ? distCentro : -distCentro;
        colididos = Physics2D.OverlapCircleAll(transform.position + soma, raioRC, lm);
        colidiu = colididos.Length > 1;
        if (colidiu)
        {
            _animator.SetBool("IndoPraBaixo", true);
            rbPlayer.velocity = new Vector3(rbPlayer.velocity.x, 0);
        }
        else
        {
            _animator.SetBool("IndoPraBaixo", false);
            rbPlayer.velocity = new Vector3(rbPlayer.velocity.x, anguloDireita ? velocidade : -velocidade);
        }
        if (Input.inputString.ToUpper() == botaoPrincipal && colidiu)
        {
            anguloRaycast = !anguloRaycast;
            //_animator.SetBool("IndoPraBaixo", );
            anguloDireita = !anguloDireita;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ciclone")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator PodeJogar()
    {
        yield return new WaitForSeconds(3);
        podeJogar = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + soma, raioRC);
    }
    private void OnDestroy()
    {
        GameController.quantidadeNavios--;
    }
}
