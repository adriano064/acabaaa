using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{

    public Transform[] pontosdocaminho;
    private int pontoatual;
    public float VelocidadeDeMovimento;
    private float ultimaposicaox;
    
    void Start()
    {
        
    }
    void Update()
    {
        MovimentoINimigo();
        EspelharNaHorizontal();
        DestruirInimigo();

    }

    private void MovimentoINimigo()
    {
        // de um ponto para o outro pegando a posição do inimigo, usando Vecto2( posição,ponto atual e velocidade)
        transform.position = Vector2.MoveTowards(transform.position, pontosdocaminho[pontoatual].position,
            VelocidadeDeMovimento * Time.deltaTime);
        if (transform.position == pontosdocaminho[pontoatual].position)
        {
            pontoatual += 1;

            ultimaposicaox = transform.localPosition.x;
            
            if (pontoatual >= pontosdocaminho.Length)
            {
                pontoatual = 0;
            }
        }
    }
    
    private void EspelharNaHorizontal()
    {
        if (transform.localPosition.x < ultimaposicaox)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (transform.localPosition.x > ultimaposicaox)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    

        public void DestruirInimigo()
        {
            Debug.Log("Inimigo destruído!");
            Destroy(gameObject);
        }
    


}
