using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    [SerializeField]
    private float jumpforce = 1.0f;
    private bool grounded;
    private Animator animator;
    [SerializeField]
    private GameObject bulletPrefab;
    private float LastShoot;
    private int Health = 5;
    private float Subiendo;

    void Start()//Coger el RigidBody del objeto al que esté asignado el script
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Subiendo = gameObject.transform.position.y;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");// Coger el input del teclado, con valores del -1 al 1

        // Flip the player
        if (horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if(horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);

        //Detectar si el jugador está subiendo
        
            
        

        //Run player animation
        if (horizontal != 0)
            animator.SetBool("running", true);
        else 
            animator.SetBool("running", false);

        Debug.DrawRay(transform.position, Vector2.down*0.15f, Color.red);
        RaycastHit2D hitGround = Physics2D.Raycast(transform.position, Vector2.down, 0.15f);
        if (hitGround) grounded = true;
        else grounded = false;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && grounded)//GetkeyDown quiere decir cuando presionas una tecla, en este caso con KeyCode hemos puesto el espacio
        {
            Jump();
        }

        if(Input.GetMouseButton(0) && (Time.time>LastShoot+0.5))
        {
            Shoot();
            LastShoot = Time.time;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpforce));
    }

    private void Shoot()
    {
        Vector3 direction;

        if(transform.localScale.x==1)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }
        GameObject bullet = Instantiate(bulletPrefab, transform.position+direction*0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);

    }


    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);

    }
}
