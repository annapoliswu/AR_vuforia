using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasket : MonoBehaviour
{
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "FallingObject")
        {
            audioManager.Play("ItemGet");
            Destroy(collision.gameObject);
        }
    }
}
