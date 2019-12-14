using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class funButtons : MonoBehaviour
{
    float index;
    [SerializeField] GameObject[] Canvas;
    [SerializeField] Animator anim;

    public void IrSel()
    {
        index = 1;
        StartCoroutine(TransPraia(0));
    }

    public void IrMenu()
    {
        TelaSelecao.ZeraTeclas();
        index = 0;
        StartCoroutine(TransPraia(1));
    }

    public void Sair()
    {
        Application.Quit();
    }

    private void Start()
    {
        index = 0;
        Canvas[0].SetActive(true);
        Canvas[1].SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKeyDown && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2) && index == 0)
            IrSel();
    }

    IEnumerator TransPraia(int caso)
    {
        switch (caso)
        {
            case 0:
                    anim.SetBool("transPraiaF", true);
                yield return new WaitForSeconds(1f);
                    anim.SetBool("transPraiaF", false);
                    Canvas[0].SetActive(false);
                    Canvas[1].SetActive(true);
                    index = 1;
                break;
            
            case 1:
                anim.SetBool("transPraiaF", true);
                yield return new WaitForSeconds(1f);
                anim.SetBool("transPraiaF", false);
                Canvas[0].SetActive(true);
                Canvas[1].SetActive(false);
                index = 0;
                break;

        }
    }
}
