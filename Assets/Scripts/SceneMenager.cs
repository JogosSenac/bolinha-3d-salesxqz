using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
}