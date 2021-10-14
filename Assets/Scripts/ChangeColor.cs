using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeColor : MonoBehaviour
{
    public GameObject vButtonObj;
    public GameObject obj;

    public Material matt;

  

    // Start is called before the first frame update
    void Start()
    {
        vButtonObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vButtonObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonReleased);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPressed(VirtualButtonBehaviour vButt)
    {
        //onOff = !onOff;
        int vrand = Random.Range(0, 2);
        Color[] colors = { Color.blue, Color.red, Color.green };
        matt.SetColor("_Color", colors[vrand]);
        Debug.Log("pressed");

    }

    public void OnButtonReleased(VirtualButtonBehaviour vButt)
    {

    }
}
