using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;

    public float spawnHeight = 25;
    public float spawnRadius = 5;

    public int spawnInterval = 3;
    public int holdBeforeDrop = 4;
    public int lifeTime = 20;


    public List<FallingObjectData> fallingObjects = new List<FallingObjectData>();
    private List<GameObject> objList = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        foreach(FallingObjectData data in fallingObjects)
        {
            data.prefab.tag = "FallingObject";
        }

    }


        // Start is called before the first frame update
        void Start()
    {

        InvokeRepeating ("SpawnObj", 0, spawnInterval);
        InvokeRepeating("DespawnObj", lifeTime, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObj()
    {
        int objNumber = Random.Range(0, fallingObjects.Count);
        float angle = Random.Range(0, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * spawnRadius;
        float z = Mathf.Cos(angle) * spawnRadius;

        Vector3 startPosition = new Vector3(x, spawnHeight, z);
        GameObject objToAdd = GameObject.Instantiate(fallingObjects[objNumber].prefab, startPosition, Quaternion.identity);

        objToAdd.GetComponent<Rigidbody>().useGravity = false;
        objToAdd.transform.parent = this.transform.parent; //set parent to imageTarget

        StartCoroutine(DropObj(objToAdd, holdBeforeDrop)); // 1 second
        objList.Add(objToAdd);

    }

    private IEnumerator DropObj(GameObject obj, float duration)
    {
        yield return new WaitForSeconds(duration);
        obj.GetComponent<Rigidbody>().useGravity = true;
    }

    private void DespawnObj()
    {   
        //can play a despawn anim here if want
        GameObject objToDestroy = objList[0];
        objList.RemoveAt(0);
        Destroy(objToDestroy);
    }

    private void DespawnObj(int listPosn)
    {
        GameObject objToDestroy = objList[listPosn];
        objList.RemoveAt(listPosn);
        Destroy(objToDestroy);
    }

}
