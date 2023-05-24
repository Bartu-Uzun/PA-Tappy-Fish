using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    private BoxCollider2D box;

    float groundWidth;
    // Start is called before the first frame update
    void Start()
    {

        box = GetComponent<BoxCollider2D>();
        groundWidth = box.size.x;

        Debug.Log(groundWidth);
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        
        if (transform.position.x <= - groundWidth) {

            transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
        }
    }
}