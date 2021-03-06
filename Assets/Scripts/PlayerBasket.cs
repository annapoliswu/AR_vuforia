using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBasket : MonoBehaviour
{
    private AudioManager audioManager;
    private UIManager uiManager;
    private int score;
    public GameObject explosionPrefab;
    public GameObject confettiPrefab;
    public GameObject stardustPrefab;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        uiManager = FindObjectOfType<UIManager>();
        score = 0;
        uiManager.SetText("ScoreScreen", "Score: "+score);
        audioManager.Play("BackgroundMusic");

    }


    void OnTriggerEnter(Collider other)
    {
        FallingObject fObj = other.gameObject.GetComponent<FallingObject>();
        if ( fObj != null)
        {
            if(fObj.data.type == "Bomb")
            {
                //end game? or play other sounds etc
                GameObject explosionEffect = Instantiate(explosionPrefab, fObj.transform.position, fObj.transform.rotation);
                Destroy(explosionEffect, 3);
                audioManager.Play("Explosion");
                StartCoroutine(EndGame(3));
            }
            else if(fObj.data.type == "Gift")
            {
                GameObject confettiEffect = Instantiate(confettiPrefab, fObj.transform.position, fObj.transform.rotation);
                Destroy(confettiEffect, 3);
                audioManager.Play("GiftGet");
            }
            else if (fObj.data.type == "Star")
            {
                GameObject stardustEffect = Instantiate(stardustPrefab, fObj.transform.position, fObj.transform.rotation);
                Destroy(stardustEffect, 3);
                audioManager.Play("StarGet");
            }
            
            score += fObj.data.points;
            uiManager.SetText("ScoreScreen", "Score: " + score);
            Destroy(other.gameObject);
        }
    }

    private IEnumerator EndGame(float duration)
    {
        yield return new WaitForSeconds(1);
        uiManager.HideScreen("ScoreScreen");
        uiManager.SetText("GameOverScreen", score + " points");
        uiManager.ShowScreen("GameOverScreen");
        yield return new WaitForSeconds(duration);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }


}
