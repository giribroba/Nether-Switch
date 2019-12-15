using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] navios;
    private void Awake()
    {
        for (int i = 0; i < navios.Length; i++)
        {
            navios[i].SetActive(TelaSelecao.teclasEscolhidas.ContainsKey(i));
            navios[i].layer = 8;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
