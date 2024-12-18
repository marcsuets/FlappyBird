using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMAnager : MonoBehaviour
{
    private GameManager gm;
    
    public TextMeshProUGUI txtInGameScore;
    public TextMeshProUGUI txtInGameBestScore;
    public TextMeshProUGUI txtGameOverMain;
    public TextMeshProUGUI txtGameOverScore;
    public Button btnPlayAgain;
    
    void Start()
    {
        gm = GameManager.Instance;
        txtGameOverMain.gameObject.SetActive(false);
        txtGameOverScore.gameObject.SetActive(false);
        btnPlayAgain.gameObject.SetActive(false);
    }

    void Update()
    {

        if (gm.getGameOver())
        {
            btnPlayAgain.gameObject.SetActive(true);
            txtGameOverMain.gameObject.SetActive(true);
            txtGameOverScore.gameObject.SetActive(true);
            txtGameOverScore.SetText("YOUR SCORE IS " + gm.getScore());
        }

        
        txtInGameScore.SetText(gm.getScore().ToString());
        txtInGameBestScore.SetText("BEST SCORE: " + gm.getScore());
    }
}
