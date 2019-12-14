using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField]private float velocidade, raioRC, distCentro;
    public int index;
    private Animator _animator;
    private Rigidbody2D rbPlayer;
    private bool anguloDireita, executar, anguloRaycast, colidiu;
    Collider2D[] colididos;
    private string botaoPrincipal;
    [SerializeField] private LayerMask lm;
    private Vector3 soma;
    private Ray r;
    void Start()
<<<<<<< HEAD
    {    
=======
    {
        
<<<<<<< HEAD
>>>>>>> 8cf17ae75cf7bceca1b6dc5dbf0a0f9bfad2339e
=======
>>>>>>> 46b2a04d5cc61e52d556ea621eedd2c968f9c8df
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
<<<<<<< HEAD

        _animator.SetBool("EncontrouParede", colidiu);

=======
>>>>>>> 46b2a04d5cc61e52d556ea621eedd2c968f9c8df
        rbPlayer.velocity = new Vector3(rbPlayer.velocity.x , anguloDireita ? velocidade : -velocidade);
        if (Input.inputString.ToUpper() == botaoPrincipal && executar && colidiu)
        {
            _animator.SetTrigger("ApertouZ");
            executar = false;
            anguloRaycast = !anguloRaycast;
            _animator.SetBool("IndoPraBaixo", !anguloRaycast);
            anguloDireita = !anguloDireita;
        }
        else
        {
            executar = true;
        }

    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + soma, raioRC);
    }
}
