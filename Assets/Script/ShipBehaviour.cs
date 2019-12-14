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
    Collider2D[] colididos, colididosClone;
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
        Movimento();
    }
    private void Movimento()
    {
        soma.y = (anguloRaycast) ? distCentro : -distCentro;
        colididos = Physics2D.OverlapCircleAll(transform.position + soma, raioRC, lm);
        colidiu = colididos.Length > 1;
        _animator.SetBool("EncontrouParede", colidiu);
        if (colidiu)
        {
            rbPlayer.velocity = new Vector3(rbPlayer.velocity.x, 0);
        }
        else if(!colidiu)
            rbPlayer.velocity = new Vector3(rbPlayer.velocity.x , anguloDireita ? velocidade : -velocidade);
        if (Input.inputString.ToUpper() == botaoPrincipal && colidiu)
        {
            _animator.SetTrigger("ApertouZ");
            anguloRaycast = !anguloRaycast;
            _animator.SetBool("IndoPraBaixo", !anguloRaycast);
            anguloDireita = !anguloDireita;
        }
    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + soma, raioRC);
    }
}
