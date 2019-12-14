using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaSelecao : MonoBehaviour
{
    private GameObject[] players;
    public static List<string> teclasescolhidas = new List<string>();
    float tempo;

    public void Game(string cena)
    {
        players = GameObject.FindGameObjectsWithTag("Caixa");
        foreach (var i in players)
        {
            teclasescolhidas.Add(i.GetComponent<CaixaPlayer>().txt_teclaEscolhida.text);
        }
        StartCoroutine("Esperar");

    }
        IEnumerator Esperar()
        {
            UI ui = this.GetComponent<UI>();
            tempo = 2;
            ui.Fades(false, tempo, Random.Range(0, 2));
            yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene("SampleScene");
        }
}
