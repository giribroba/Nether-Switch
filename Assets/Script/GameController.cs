using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    Rigidbody2D rbCamera;
    UI fade;
    [SerializeField] GameObject[] navios;
    private void Awake()
    {
        fade = transform.GetComponent<UI>();
        fade.Fades(true,1,Random.Range(0,2));
        TelaSelecao.teclasEscolhidas.Add(10, "A");
        rbCamera = GetComponent<Rigidbody2D>();
        for (int i = 0; i < navios.Length; i++)
        {
            navios[i].SetActive(TelaSelecao.teclasEscolhidas.ContainsKey(i));
            navios[i].layer = 8;
        }
    }
    private void Update()
    {
        rbCamera.velocity = new Vector3(velocidade, rbCamera.velocity.y);
        Time.timeScale = 1.5f; 
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag != "Obstaculo")
            Destroy(other.gameObject);
    }
}
