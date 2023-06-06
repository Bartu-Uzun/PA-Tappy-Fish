using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //// DONT FORGET WHEN CREATING A UI SCRIPT!!!!
public class Score : MonoBehaviour
{

    private int score = 0;
    private int highScore;
    private Text scoreText; // Text is a UnityEngine.UI class
    [SerializeField] private Text panelHighScoreText;
    [SerializeField] private Text panelScoreText;
    [SerializeField] private GameObject newText;


    // Start is called before the first frame update
    void Start()
    {

        score = 0;

        //PlayerPrefs: the place where we store key-value pairs
        //here, the key is "highScore", and the value is the highScore
        // To clear PlayerPrefs: edit --> clear all PlayerPrefs
        scoreText = GetComponent<Text>();

        scoreText.text = score.ToString();
        panelScoreText.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highScore");
        panelHighScoreText.text = highScore.ToString();

        

    }

    public void Scored() {

        score ++;
        scoreText.text = score.ToString();
        panelScoreText.text = score.ToString();

        if (score > highScore) {
            highScore = score;
            panelHighScoreText.text = highScore.ToString();

            //PlayerPrefs!!!
            PlayerPrefs.SetInt("highScore", highScore);

            newText.SetActive(true);
        }
    }

    public int getScore() {

        return score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
