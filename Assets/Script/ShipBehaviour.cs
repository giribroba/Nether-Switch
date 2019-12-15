using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField]private float velocidade, raioRC, distCentro;
    public int index;
    private Animator _animator;
    private Rigidbody2D rbPlayer;
    private bool anguloDireita, anguloRaycast, colidiu;
    Collider2D[] colididos;

    private string botaoPrincipal;
    [SerializeField] private LayerMask lm;
    private Vector3 soma;
    private Ray r;
    void Start()

    {
        botaoPrincipal = TelaSelecao.teclasEscolhidas[index];
        rbPlayer = GetComponent<Rigidbody2D>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = anguloRaycast;
        Movimento();
        _animator.SetFloat("Velocidade", rbPlayer.velocity.y);
    }
    private void Movimento()
    {
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
            rbPlayer.velocity = new Vector3(rbPlayer.velocity.x , anguloDireita ? velocidade : -velocidade);
        }
       
        if (Input.inputString.ToUpper() == botaoPrincipal && colidiu)
        {
            
            anguloRaycast = !anguloRaycast;
            //_animator.SetBool("IndoPraBaixo", );
            anguloDireita = !anguloDireita;
        }
        rbPlayer.velocity = new Vector3(velocidade, rbPlayer.velocity.y);
    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + soma, raioRC);
    }
}
