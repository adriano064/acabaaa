using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{

    public Transform[] waypoints;  // Pontos para os quais o inimigo se moverá
    public float moveSpeed = 3f;   // Velocidade de movimento do inimigo

    private int currentWaypoint = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        Vector2 targetPosition = waypoints[currentWaypoint].position;
        Vector2 currentPosition = rb.position;

        // Move o inimigo em direção ao ponto de destino
        Vector2 movement = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        rb.MovePosition(movement);

        // Calcula a direção para o próximo ponto de destino
        Vector2 direction = (targetPosition - currentPosition).normalized;

        // Calcula o ângulo da rotação em radianos apenas no eixo Y
        float angleInRadians = Mathf.Atan2(direction.y, direction.x);

        // Converte o ângulo de radianos para graus e cria um vetor de rotação
        Vector3 newRotation = transform.eulerAngles;
        newRotation.y = angleInRadians * Mathf.Rad2Deg;

        // Define a rotação usando eulerAngles
        transform.eulerAngles = newRotation;

        // Verifica se o inimigo chegou ao ponto de destino
        if (Vector2.Distance(currentPosition, targetPosition) < 0.1f)
        {
            // Incrementa para o próximo ponto de destino
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

    


}
