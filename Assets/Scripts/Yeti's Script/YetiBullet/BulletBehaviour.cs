using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class BulletBehaviour : MonoBehaviour
{
    public YetiBoss yeti;
    private SpriteRenderer bulletRenderer;
    [SerializeField] private Transform player;
    private Rigidbody2D rb;
    private float speed = 3f;
    private Vector2 target;

    void Start()
    {
        bulletRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        // Inizializza il bersaglio alla posizione del giocatore
        target = player.position;

        // Gestisce il flip del proiettile
        Flip();

        // Calcola la direzione di movimento verso il giocatore
        Vector2 moveDirection = (target - rb.position).normalized;

        // Imposta la velocità del proiettile
        rb.velocity = moveDirection * speed;
    }

    private void Flip()
    {
        if (yeti.flip)
        {
            bulletRenderer.flipX = true;
            Debug.Log("Flip!");
        }
        else
        {
            bulletRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colpito");
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}


