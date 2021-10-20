using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasket : MonoBehaviour
{
    private AudioManager audioManager;
    private UIManager uiManager;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        uiManager = FindObjectOfType<UIManager>();
        score = 0;
        uiManager.setScore(score);

    }


    void OnTriggerEnter(Collider other)
    {
        FallingObject fObj = other.gameObject.GetComponent<FallingObject>();
        if ( fObj != null)
        {
            if(fObj.data.type == "Bomb")
            {
                //end game? or play other sounds etc
            }
            audioManager.Play("ItemGet");
            score += fObj.data.points;
            uiManager.setScore(score);
            Destroy(other.gameObject);
        }
    }

  
}
