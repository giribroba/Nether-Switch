using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parallaxOceano : MonoBehaviour
{
    [SerializeField]float parallaxValor, parallaxAdicao;
    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        parallaxValor += parallaxAdicao;
        sr.material.SetTextureOffset("_MainTex", new Vector2(-parallaxValor, 0f));   
    }
}
