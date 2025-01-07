using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private GameManager gm;
    public void MoveToScene(int idScene)
    {
        gm = GameManager.Instance;

        if (idScene == 1)
        {
            gm.setGameOver(false);
            gm.resetScore();
        } 
        
        gm.PlaySound(0);
        SceneManager.LoadScene(idScene);
    }
}
