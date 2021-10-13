using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnNewInsect : MonoBehaviour
{
    public TrackableBehaviour theTrackable;
    public GameObject vButtonObj2;
    public GameObject prefabMoth;
    public GameObject prefabGnat;


    // Start is called before the first frame update
    void Start()
    {
        vButtonObj2 = GameObject.Find("insectButton");
        vButtonObj2.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vButt2){
        Insect newbug;

        if (Random.value > 0.5f)
        {
            newbug = new Moth();
            newbug.SpawnSelf(prefabMoth, theTrackable); //spawn prefab
        }
        else
        {
            newbug = new Gnat(); 
            newbug.SpawnSelf(prefabGnat, theTrackable); 
        }

        CreatureManager.AddCreature(newbug);
    }


    public void OnButtonReleased(VirtualButtonBehaviour vButt2){
    }
}
