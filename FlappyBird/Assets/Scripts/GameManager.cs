using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameOver;
    private int score;
    
    public static GameManager Instance { get; private set; }
    
    private void Awake()
    {
        gameOver = false;
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        
        score = 0;
    }

    private void Update()
    {
        Debug.Log("Game Over: " + gameOver);
        Debug.Log("Score: " + score);
    }

    public void setGameOverTrue()
    {
        gameOver = true;
    }

    public bool getGameOver()
    {
        return gameOver;
    }

    public void incrementScore()
    {
        score++;
    }

    public void resetScore()
    {
        score = 0;
    }

    public int getScore()
    {
        return score;
    }

    public void reloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}