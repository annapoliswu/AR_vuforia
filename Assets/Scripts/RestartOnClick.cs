using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnButtonPress()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
