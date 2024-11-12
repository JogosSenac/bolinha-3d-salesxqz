using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarCenas : MonoBehaviour
{

    public void Start()
    {

    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void Fase1()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
    public void Fase2()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

}