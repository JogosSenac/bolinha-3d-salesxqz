using System.Collections;
using System.Collections.Generic;
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
    [SerializeField]private int pontos;
    [SerializeField]private bool estaVivo;
    // Start is called before the first frame update
    void Start()
    {
        estaVivo = true;
        rb = GetComponent<Rigidbody>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if(estaVivo == true)
        {
            moveV = Input.GetAxis("Vertical");
            moveH = Input.GetAxis("Horizontal");
            transform.position += new Vector3(moveH * Time.deltaTime, 0, moveV * Time.deltaTime );

            //Pulo
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
            }  
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
    private void OnColisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Lava"))
        {
            estaVivo = false;
            Time.timeScale = 0;
        }
    }
}
