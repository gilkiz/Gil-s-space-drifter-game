using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60; 
        Pause();
    }
    public void Play()
    {
        score = 0;
        scoreText.text=score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;   
        Enemy1[] enemies = FindObjectsOfType<Enemy1>();
        for(int i=0; i<enemies.Length;i++){
            Destroy(enemies[i].gameObject);
        }
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause(); 
    } 
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;     
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text=score.ToString(); 
    }


//! need to fix actual values of if !
    public bool isFivePoints()
    {
        return (score > 1 && score <= 2);
    }
    public bool isTenPoints()
    {
        return (score > 2 && score <= 3);
    }
    public bool isFifteenPoints()
    {
        return (score > 3 && score <= 4);
    }
    public bool isTwentyPoints()
    {
        return (score > 4 && score <= 5);
    }
    public bool isTwentyFivePoints()
    {
        return (score > 5 && score <= 6);
    }
}
