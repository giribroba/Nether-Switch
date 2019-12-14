using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaSelecao : MonoBehaviour
{
    private GameObject[] players;
    public static Dictionary<int, string> teclasEscolhidas = new Dictionary<int, string>();

    public void Game(string cena)
    {
        players = GameObject.FindGameObjectsWithTag("Caixa");
        foreach (var i in players)
        {
            var temp = i.GetComponent<CaixaPlayer>();
            if (temp.ativado)
                teclasEscolhidas.Add(temp.id, temp.txt_teclaEscolhida.text);
        }
        SceneManager.LoadScene(cena);
    }
}
