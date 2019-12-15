using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    public static float quantidadeNavios;
    Rigidbody2D rbCamera;
    UI fade;
    [SerializeField] GameObject[] navios;
    [SerializeField] GameObject gameOverScreen;
    public static Sprite SpriteVencedor { get; set; }
    [SerializeField] AudioSource ambienteSom, vitoriaSom;
    public static AudioSource[] hits;
    [SerializeField] private AudioSource[] hitsClone;
    public static bool podeJogar = false;

    private void Awake()
    {
        hits = hitsClone;
        fade = transform.GetComponent<UI>();
        fade.Fades(true,2,1);
        TelaSelecao.teclasEscolhidas.Add(7, "A");
        rbCamera = GetComponent<Rigidbody2D>();
        for (int i = 0; i < navios.Length; i++)
        {
            navios[i].SetActive(TelaSelecao.teclasEscolhidas.ContainsKey(i));
            if (TelaSelecao.teclasEscolhidas.ContainsKey(i))
            {
                quantidadeNavios++;
            }
            navios[i].layer = 8;
        }
    }

    private void Update()
    {
        if (podeJogar)
        {
            rbCamera.velocity = new Vector3(velocidade, rbCamera.velocity.y);
        }
        else
        {
            rbCamera.velocity = Vector3.zero;
        }
        Time.timeScale = 1.5f; 
        if(quantidadeNavios <= 0)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("PodeJogar");
        }

        if (podeJogar && começoTela != null)
        {
            Destroy(começoTela);
        }
        else if(!podeJogar && começoTela != null)começoTela.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(começoTxt());
        }
    }

    public GameObject começoTela;
    public Text txtComeçoTela;
    IEnumerator PodeJogar()
    {
        yield return new WaitForSeconds(3);
        podeJogar = true;
    }
    public void TrocarCena(string cena)
    {
        SceneManager.LoadScene(cena);

    }
    void Venceu()
    {
        //pega o sprite do IdVencedor e mostra na tela quem foi o melhor navio da frota WinnerScreen.SetActive(true);

    }
    private void GameOver()
    {
        ambienteSom.Stop();
        podeJogar = false;
        TelaSelecao.ZeraTeclas();
        TelaSelecao.teclasEscolhidas = new Dictionary<int, string>();
        gameOverScreen.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Obstaculo")
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator começoTxt()
    {
        txtComeçoTela.text = "3";
        yield return new WaitForSeconds(1f);
        txtComeçoTela.text = "2";
        yield return new WaitForSeconds(1f);
        txtComeçoTela.text = "1";

    }
}
