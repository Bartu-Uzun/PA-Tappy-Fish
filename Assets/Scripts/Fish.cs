using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    private Rigidbody2D rb;

    int angle;
    int maxAngle = 20;
    int minAngle = -60;

    [SerializeField] private float speed = 9f;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }

        if (rb.velocity.y > 0) {

            if (angle < maxAngle) {

                angle = angle + 4;
            }
        }
        else if (rb.velocity.y < -2.5f) {

            if (angle > minAngle) {

                angle = angle - 2;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
        
    }
}
