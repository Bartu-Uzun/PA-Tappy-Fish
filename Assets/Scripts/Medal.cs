using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{

    [SerializeField] private Sprite metalMedal, bronzeMedal, silverMedal, goldMedal;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {

        image = GetComponent<Image>();

        
        
    }

    // Update is called once per frame
    void Update()
    {

        int gameScore = GameManager.gameScore;

        CalculateMedal(gameScore);
        
    }

    private void CalculateMedal(int gameScore)
    {
        if (gameScore <= 5) {
            image.enabled = false;
        }
        if (gameScore > 5 && gameScore <= 10) {
            image.sprite = metalMedal;
            
        }
        else if (gameScore > 10 && gameScore <= 15) {
            image.sprite = bronzeMedal;
          
        }
        else if (gameScore > 15 && gameScore <= 20) {
            image.sprite = silverMedal;
       
        }
        else if (gameScore > 20) {
            image.sprite = goldMedal;
     
        }
        
    }
}
