using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateBestScoreTxt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Best score: " + PlayerPrefs.GetInt("BestScore");
    }
}
