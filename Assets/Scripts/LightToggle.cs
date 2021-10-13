using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class LightToggle : MonoBehaviour
{

    public GameObject vButtonObj;
    public GameObject myGraphic;

    private bool onOff;

    // Start is called before the first frame update
    void Start()
    {
        vButtonObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vButtonObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonReleased);
        myGraphic.SetActive(false);
        onOff = false;
        CreatureManager.ChangeLightState(onOff);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vButt){
        onOff = !onOff;
        myGraphic.SetActive(onOff);
        CreatureManager.ChangeLightState(onOff);

    }

    public void OnButtonReleased(VirtualButtonBehaviour vButt){

    }
}
