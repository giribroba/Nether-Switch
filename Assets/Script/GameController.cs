using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    Rigidbody2D rbCamera;
    [SerializeField] GameObject[] navios;
    private void Awake()
    {
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
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
