using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaSelecao : MonoBehaviour
{
    private static GameObject[] players;
    private float tempo;
    public static Dictionary<int, string> teclasEscolhidas = new Dictionary<int, string>();

    public void Game(string cena)
    {
        players = GameObject.FindGameObjectsWithTag("Caixa");
        foreach (var i in players)
        {
            var temp = i.GetComponent<CaixaPlayer>();
            if (temp.ativado && temp.txt_teclaEscolhida.text != "...")
                teclasEscolhidas.Add(temp.id, temp.txt_teclaEscolhida.text);
        }
        if (!(teclasEscolhidas.Count == 0))
        {
            StartCoroutine("Esperar", cena);
        }
    }
    public static void ZeraTeclas()
    {
        players = GameObject.FindGameObjectsWithTag("Caixa");
        CaixaPlayer.portaTeclas = new List<string>();
        foreach (var i in players)
        {
            i.GetComponent<CaixaPlayer>().ativado = false;
        }
    }
    IEnumerator Esperar(string cena)
    {
        UI ui = this.GetComponent<UI>();
        tempo = 2;
        ui.Fades(false, tempo, Random.Range(0, 2));
        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene(cena);
    }
}
