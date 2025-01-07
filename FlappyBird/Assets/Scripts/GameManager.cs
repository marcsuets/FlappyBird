using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameOver;
    private int score;
    
    public AudioSource audioSource; 
    public AudioClip[] sounds;
    
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
    
    public void setGameOver (bool booleanGO)
    {
        gameOver = booleanGO;
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

    public void saveBestScore()
    {
        if (getScore() > getBestScore())
        {
            PlayerPrefs.SetInt("BestScore", getScore());
        }
    }

    public int getBestScore()
    {
        return PlayerPrefs.GetInt("BestScore");
    }
    
    public void PlaySound(int soundIndex)
    {
        if (soundIndex >= 0 && soundIndex < sounds.Length)
        {
            audioSource.PlayOneShot(sounds[soundIndex]);
        }
        else
        {
            Debug.LogWarning("Sound index out of range: " + soundIndex);
        }
    }
}