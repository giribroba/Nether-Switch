using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscreveTexto : MonoBehaviour
{
    private float intervalo = 0.1f;
    private string[] textos;
    private string textoCompleto = "", textoAtual = "";

    private void Awake()
    {
        textos = new string[] {"Oceano Atlântico 1637...", "Destino: Brasil...", "Frota de Nassau"};
    }

    private void Start()
    {
        StartCoroutine("ApareceTexto");
    }

    public IEnumerator ApareceTexto()
    {
        for (int j = 0; j < textos.Length; j++)
        {
            textoCompleto = textos[j];
            for (int i = 0; i <= textoCompleto.Length; i++)
            {
                textoAtual = textoCompleto.Substring(0, i);
                this.GetComponent<Text>().text = textoAtual;
                yield return new WaitForSeconds(intervalo);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
