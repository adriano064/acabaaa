using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{

    public int health = 5;
    private Rigidbody2D rig;
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    [Header("Input")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;
    
    [Header("Sprites")]
    public spriteanim spriteRendererUp;
    public spriteanim spriteRendererDown;
    public spriteanim spriteRendererLeft;
    public spriteanim spriteRendererRight;
    public spriteanim spriteRendererDeath;
    private spriteanim activeSpriteRenderer;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;

    }

    private void Update()
    {
        if (Input.GetKey(inputUp))
        {
            PegarDirecao(Vector2.up,spriteRendererUp);
        }
        else if (Input.GetKey(inputDown))
        {
            PegarDirecao(Vector2.down,spriteRendererDown);
        }
        else if (Input.GetKey(inputLeft))
        {
            PegarDirecao(Vector2.left,spriteRendererLeft);
        }
        else if (Input.GetKey(inputRight))
        {
            PegarDirecao(Vector2.right,spriteRendererRight);
        }
        else
        {
            PegarDirecao(Vector2.zero,activeSpriteRenderer);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rig.position;
        Vector2 translation = speed * Time.fixedDeltaTime * direction;

        rig.MovePosition(position + translation);
    }

    private void PegarDirecao(Vector2 newDirection, spriteanim  spriteRenderer)
    {
        direction = newDirection;
        
        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }
//oi
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion") || other.gameObject.layer == LayerMask.NameToLayer("inimigo"))
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().CheckWinState();
    }


    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().CheckWinState();
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        if (health < 0)
        {
            
        }
    }
}
