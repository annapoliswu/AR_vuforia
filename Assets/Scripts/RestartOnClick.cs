using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartOnClick : MonoBehaviour
{

    UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonPress);
        uiManager.GetComponent<UIManager>();

    }
    public void OnButtonPress()
    {
        uiManager.SetText("GameOverScreen", "pressed");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        
    }
}
