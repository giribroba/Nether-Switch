using System.Collections.Generic;
using UnityEngine;

public class TelaSelecao : MonoBehaviour
{
    private GameObject[] players;
    public static List<string> teclasescolhidas = new List<string>();
    public void Game()
    {
        players = GameObject.FindGameObjectsWithTag("Caixa");
        foreach (var i in players)
        {
            teclasescolhidas.Add(i.GetComponent<CaixaPlayer>().txt_teclaEscolhida.text);
        }
    }
}
