using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] Score score;

    [SerializeField] GameManager gameManager;
    [SerializeField] ObstacleFactory obstacleFactory;
    [SerializeField] AudioSource swim, hit, point;

    Animator anim;

    private bool touchedGround = false;

    int angle;
    int maxAngle = 20;
    int minAngle = -60;

    [SerializeField] private float speed = 9f;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0; //game has not started yet!

        anim = GetComponent<Animator>();

        
        
    }

    // use Update() when: it is essential to read user inputs ASAP
    void Update()
    {
        

        FishSwim();

    }
    //use FixedUpdate() when: user input not needed, you want a motion, etc to be updated on a regular basis
    // FixedUpdate() will work the same for every device, Update() will not
    // use FixedUpdate() if physics involved!!
    private void FixedUpdate() {

        SetRotation();
        
    }

    private void SetRotation()
    {
        if (rb.velocity.y > 0)
        {

            if (angle < maxAngle)
            {

                angle = angle + 4;
            }
        }
        else if (rb.velocity.y < -2.5f)
        {

            if (angle > minAngle)
            {

                angle = angle - 2;
            }
        }

        if (!touchedGround) {

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void FishSwim(){

        if (Input.GetMouseButtonDown(0) && !GameManager.gameOver) {

            swim.Play();

            if (!GameManager.gameStarted) {

                StartGame();
            }

            rb.velocity = new Vector2(0,0);
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }

    private void StartGame()
    {
        rb.gravityScale = 1.8f;
        obstacleFactory.InstantiateObstacle();
        gameManager.StartGame();
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
         // you scored!
        if (other.CompareTag("Obstacle")) {
            
            point.Play();
            score.Scored();
        }
        else if (other.CompareTag("Column") && !GameManager.gameOver) {

            //GameOver

            hit.Play();
            gameManager.GameOver();
           
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.CompareTag("Ground")) {

            //GameOver
            
            
            if (!GameManager.gameOver) { //GameManager's GameOver

                hit.Play();
                gameManager.GameOver();
            }
            
            GameOver();
            
            

        }
    }

    void GameOver() {

        touchedGround = true;

        transform.rotation = Quaternion.Euler(0, 0, -90);

        anim.enabled = false;


    }
}
