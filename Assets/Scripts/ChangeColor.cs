using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeColor : MonoBehaviour
{
    public GameObject vButtonObj;
    public GameObject obj;

    private Color objColor;

    // Start is called before the first frame update
    void Start()
    {
        vButtonObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vButtonObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonReleased);
        objColor = obj.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPressed(VirtualButtonBehaviour vButt)
    {
        //onOff = !onOff;
        int vR = Random.Range(0, 255);
        int vG = Random.Range(0, 255);
        int vB = Random.Range(0, 255);
        objColor = new Color(vR, vG, vB);

    }

    public void OnButtonReleased(VirtualButtonBehaviour vButt)
    {

    }
}
