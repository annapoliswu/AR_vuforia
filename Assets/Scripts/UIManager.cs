using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    private Canvas canvas;
    private TMPro.TextMeshProUGUI scoreText; 

    void Awake()
    {
        //TODO
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        canvas = GetComponentInChildren<Canvas>();
        scoreText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }
}
