﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField]private float velocidade, raioRC, distCentro;
    private Animator _animator;
    private Rigidbody2D rbPlayer;
    private bool anguloDireita, executar, colidiu, anguloRaycast;
    private string botaoPrincipal;
    [SerializeField] private LayerMask lm;
    private Vector3 soma;
    private Ray r;

    void Start()
    {
        botaoPrincipal = "A";
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
        colidiu = Physics2D.OverlapCircle(transform.position + soma, raioRC, lm);
        rbPlayer.velocity = new Vector3(rbPlayer.velocity.x , anguloDireita ? velocidade : -velocidade);
        if (Input.inputString.ToUpper() == botaoPrincipal && executar && colidiu)
        {
            executar = false;
            anguloRaycast = !anguloRaycast;
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