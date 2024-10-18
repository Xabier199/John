using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float speed = 1.0f;

    private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    public void SetDirection(Vector2 direction)
    { 
        this.direction = direction;
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
