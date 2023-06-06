using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject obstacle;
    [SerializeField] private float maxTime;

    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private float randomY;
    float timer;
    void Start()
    {

        timer = 0;
    
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.gameOver && GameManager.gameStarted) {

            timer += Time.deltaTime;

            if (timer >= maxTime) {
                InstantiateObstacle();
                timer = 0;
            }
        }
        
    }

    public void InstantiateObstacle() {

        randomY = Random.Range(minY, maxY);

        GameObject newObstacle = Instantiate(obstacle);

        newObstacle.transform.position = new Vector2(transform.position.x, randomY);

    }
}
