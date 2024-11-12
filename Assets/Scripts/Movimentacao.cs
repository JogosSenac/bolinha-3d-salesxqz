using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;

public class Movimentacao : MonoBehaviour
{
    private float moveV;
    private float moveH;
    private Rigidbody rb;
    [SerializeField]private float velocidade;
    [SerializeField]private float forcaPulo;
    [SerializeField]private bool invertH;
    [SerializeField]private bool invertV;
    [Header("Sons da Bolinha")]
    [SerializeField] private AudioClip pulo;
    [SerializeField] private AudioClip morte;
    [SerializeField] private AudioClip pegaCubo;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField]public static int pontos;
    [SerializeField]public static bool estaVivo;
    [SerializeField] private Vector3 posicaoInicial;
    // Start is called before the first frame update
    void Start()
    {
        estaVivo = true;
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
        posicaoInicial = transform.position;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(estaVivo == true)
        {
            Time.timeScale = 1;
            moveV = Input.GetAxis("Vertical");
            moveH = Input.GetAxis("Horizontal");
            transform.position += new Vector3(moveH * velocidade * Time.deltaTime, 0, moveV * velocidade *Time.deltaTime );

            //Pulo
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
                audioPlayer.PlayOneShot(pulo);
            }  
        }
        
    }
    
    private void OnTriggerEnter(Collider cubo)
    {
        Destroy(cubo.gameObject);
        audioPlayer.PlayOneShot(pegaCubo);
        pontos++;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Lava"))
        {
            estaVivo = false;
            Time.timeScale = 0;
            audioPlayer.PlayOneShot(morte);
        }
        if(other.gameObject.CompareTag("Portal") && pontos < 16)
        {
            VoltarParaPosicaoInicial();
        }
        if (other.gameObject.CompareTag("Portal") && pontos == 16)
        {
            SceneManager.LoadScene("fase2");
            pontos = 0;
        }
        if (other.gameObject.CompareTag("Portal2") && pontos == 16)
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void VoltarParaPosicaoInicial()
    {
        transform.position = posicaoInicial;
    }
    public int PegaPontos()
    {
        return pontos;
    }
    public bool VerificaVidaPlayer()
    {
        return estaVivo;
    }
}
