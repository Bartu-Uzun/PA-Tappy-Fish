using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //SCREENMANAGEMENT!!!!!!
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static Vector2 bottomLeft;
    public static bool gameOver;
    public static bool gameStarted;
    public static int gameScore;
    [SerializeField] GameObject score;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject getReadyPanel;

    private void Awake() {
        
        //ScreenToWorldPoint: turns our screen point to a world point (calculations using a world point is possible even when it is out of the screen)
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0)); //bottomLeft is the bottomLeft of the screen
    }
    void Start()
    {
        gameOver = false;
        gameStarted = false;
    }

    public void GameOver() {
        gameOver = true;

        gameOverPanel.SetActive(true);
        gameScore = score.GetComponent<Score>().getScore();
        score.SetActive(false);
    }

    public void StartGame() {
        gameStarted = true;
        getReadyPanel.SetActive(false);
    }

    public void RestartGame() {

        //In the game we have only one scene, which is the active scene. So the active scene will be reload
        // to see the scenes, File --> build settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
