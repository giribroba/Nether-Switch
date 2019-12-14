using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] navios;
    private void Awake()
    {
        for (int i = 0; i < navios.Length; i++)
        {
            navios[i].SetActive(TelaSelecao.teclasEscolhidas.ContainsKey(i));
        }
    }
}
