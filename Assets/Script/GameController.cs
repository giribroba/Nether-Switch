using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    public static float quantidadeNavios;
    Rigidbody2D rbCamera;
    UI fade;
    [SerializeField] GameObject[] navios;
    [SerializeField] GameObject gameOverScreen;
    private void Awake()
    {
        fade = transform.GetComponent<UI>();
        fade.Fades(true,1,Random.Range(0,2));
        TelaSelecao.teclasEscolhidas.Add(10, "A");
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
        rbCamera.velocity = new Vector3(velocidade, rbCamera.velocity.y);
        Time.timeScale = 1.5f; 
        if(quantidadeNavios <= 0)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag != "Obstaculo")
            Destroy(other.gameObject);
    }
}
