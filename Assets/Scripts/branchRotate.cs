using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class branchRotate : MonoBehaviour
{
    public GameObject leftBranch;
    public GameObject rightBranch;
    public float leftSpeed;
    public float rightSpeed;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(RotateRightBranch());
    }

    // Update is called once per frame
    void Update()
    {

        transform.RotateAround(leftBranch.transform.position, -this.transform.forward, leftSpeed * Time.deltaTime);

        transform.RotateAround(rightBranch.transform.position, -this.transform.forward, rightSpeed * Time.deltaTime);
    }

   // private IEnumerator RotateRightBranch()
   // {
        
    //    yield return new WaitForSeconds(1);
        
    //}
}
