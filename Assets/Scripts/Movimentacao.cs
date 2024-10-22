using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

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
    [SerializeField] private AudioClip pegaCubo;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField]public static int pontos;
    [SerializeField]public static bool estaVivo;
    // Start is called before the first frame update
    void Start()
    {
        estaVivo = true;
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if(estaVivo == true)
        {
            moveV = Input.GetAxis("Vertical");
            moveH = Input.GetAxis("Horizontal");
            transform.position += new Vector3(moveH * velocidade * Time.deltaTime, 0, moveV * velocidade *Time.deltaTime );

            //Pulo
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
            }  
        }
        
    }
    
    private void OnTriggerEnter(Collider cubo)
    {
        Destroy(cubo.gameObject);
        audioPlayer.PlayOneShot(pegaCubo);
        pontos++;
    }

    private void OnCollisionEnter(Collision Lava)
    {
        if(Lava.gameObject.CompareTag("Lava"))
        {
            estaVivo = false;
            Time.timeScale = 0;
        }
    }

}
