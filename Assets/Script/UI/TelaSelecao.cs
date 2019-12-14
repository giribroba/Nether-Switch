using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaSelecao : MonoBehaviour
{
    private GameObject[] players;
    public static List<string> teclasescolhidas = new List<string>();
    public void Game(string cena)
    {
        players = GameObject.FindGameObjectsWithTag("Caixa");
        foreach (var i in players)
        {
            teclasescolhidas.Add(i.GetComponent<CaixaPlayer>().txt_teclaEscolhida.text);
        }
        SceneManager.LoadScene(cena);
    }
}
