using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMAnager : MonoBehaviour
{
    private GameManager gm;
    
    
    public TextMeshProUGUI txtInGameScore;
    public TextMeshProUGUI txtInGameBestScore;
    public TextMeshProUGUI txtFinalScore;
    public TextMeshProUGUI txtFinalMessage;
    public 
    void Start()
    {
        gm = GameManager.Instance;
    }

    void Update()
    {
        txtInGameScore.SetText(gm.getScore().ToString());
        txtInGameBestScore.SetText("BEST SCORE: " + gm.getScore());
    }
}
