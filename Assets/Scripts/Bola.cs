using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    [SerializeField] private float velocidad = 10.0f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke(nameof(GoBall), 2);
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidad);
        //Por ahora no hace nada, dado que no modifica la velocidad
    }
    private void GoBall()
    {
        float rand = Random.Range(0, 2);
        if(rand<1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }
    private void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    private void ResetGame()
    {
        ResetBall();
        Invoke(nameof(GoBall), 1);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
