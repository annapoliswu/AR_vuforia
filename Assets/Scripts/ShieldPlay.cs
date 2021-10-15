using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ShieldPlay : MonoBehaviour
{

    public GameObject vButtonObj;
    public GameObject myGraphic;

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
        Animator anim = myGraphic.GetComponent<Animator>();
        anim.Play("ImageTarget");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vButt)
    {

    }
}
