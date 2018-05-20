using UnityEngine;
using System.Collections;

public class Player_Controls : MonoBehaviour {

    private SpriteRenderer spriteControl;
    private Rigidbody2D playerBody;
    private Animator animatorControl;


    private Vector2 axis;
    private bool lastFlip;

    Spaceship spaceship;

    //void Start() {

    //    spriteControl = GetComponent<SpriteRenderer>();
    //    animatorControl = GetComponent<Animator>();
    //    audio = GetComponent<AudioSource>();
    //    playerBody = GetComponent<Rigidbody2D>();
    //}

    void Start()
    {
        spaceship = GetComponent<Spaceship>();

        StartCoroutine("Shoot");

    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GetComponent<AudioSource>().Play();
            // le paso la posicion de la nave
            spaceship.Shot(transform);

          //  le asigno un tiempo entre tiro y tiro
                 yield return new WaitForSeconds(spaceship.shotDelay);
        }

    }

    // Update is called once per frame
    void Update () {


        spriteControl = GetComponent<SpriteRenderer>();
        animatorControl = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();

        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");

        // la direccion
        Vector2 direction = new Vector2(axis.x, axis.y).normalized;

        // Move
        spaceship.Move(direction);

        Flip(axis.x);
        updateTurnAnimation(axis);
        //MovementViaVelocity(axis, speed);

    }

    public void MovementViaVelocity(Vector2 axis, float speed)
    {
        playerBody.velocity = new Vector2(axis.x * speed, axis.y);
    }

    public void MovementViaTransform(Vector2 axis, float speed)
    {
        var move = new Vector3(axis.x, axis.y, 0);
        transform.position += move * speed * Time.deltaTime;
    }

    private void updateTurnAnimation(Vector2 move)
    {
        if (move.x != 0)
        {
            animatorControl.SetBool("Turn", true);
        }
        else if (move.x == 0 || move.y == 0)
        {
            animatorControl.SetBool("Turn", false);
        }
    }

    private void Flip(float movement)
    {
        lastFlip = spriteControl.flipX;

        if (movement < 0)
        {
            spriteControl.flipX = true;
        }
        else if (movement > 0)
        {
            spriteControl.flipX = false;
        }
        else
        {
            spriteControl.flipX = lastFlip;
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        if (layerName == "Bullet Enemy")
        {
            Destroy(c.gameObject);
        }

        if (layerName == "Bullet Enemy" || layerName == "Enemy")
        {
            spaceship.Explosion();
            Destroy(gameObject);
        }
    }
}
