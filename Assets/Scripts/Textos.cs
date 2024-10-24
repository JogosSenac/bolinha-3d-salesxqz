using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Textos : MonoBehaviour
{
    public TextMeshProUGUI textoPontos;
    public TextMeshProUGUI textoDeveres;
    public TextMeshProUGUI Creditos;
    // Start is called before the first frame update
    void Start()
    {
        AtualizarTexto();
    }

    // Update is called once per frame
    void Update()
    {
        AtualizarTexto();
    }

    void AtualizarTexto()
    {
        textoPontos.text = Movimentacao.pontos.ToString() + "/16";
        if (Movimentacao.pontos == 0)
        {
            textoDeveres.text = ("Colete todos os cubos para passar de fase");
        }
        if (Movimentacao.pontos == 8)
        {
            textoDeveres.text = ("Só mais um pouco");
        }
        if (Movimentacao.pontos == 16)
        {
            textoDeveres.text = ("Vá para o Portal!");
        }
        if (Movimentacao.estaVivo == false)
        {
            textoDeveres.text =("Você Morreu!!");
        }
    }
}
