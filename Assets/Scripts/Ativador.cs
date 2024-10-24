using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativador : MonoBehaviour
{
    public GameObject canvaCredito;
    public GameObject canvaMenu;
    // Start is called before the first frame update
    public void Start()
    {
        canvaCredito.SetActive(false);
        canvaMenu.SetActive(true);
    }

    // Update is called once per frame
    public void Ativando()
    {
        canvaCredito.SetActive(true);
        canvaMenu.SetActive(false);
    }

    public void Desativar()
    {
        canvaCredito.SetActive(false);
        canvaMenu.SetActive(true);
    }    
}
