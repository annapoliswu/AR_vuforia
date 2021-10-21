using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public Screen[] screens;

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

        foreach(Screen s in screens)
        {
            s.panel.SetActive(false);
        }

        ShowScreen("ScoreScreen");
    }


    private Screen GetScreen(string name)
    {
        return Array.Find(screens, screen => screen.name == name);
    }

    public void SetText(string name, string str)
    {
        Screen screen = GetScreen(name);
        screen.editText.text = str;
    }

    public void HideScreen(string name)
    {
        Screen screen = GetScreen(name);
        screen.panel.SetActive(false);
    }

    public void ShowScreen(string name)
    {
        Screen screen = GetScreen(name);
        screen.panel.SetActive(true);
    }

}
