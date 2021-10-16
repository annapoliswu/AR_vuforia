using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;
    public GameObject obj;

    public int spawnHeight = 25;
    public int spawnInterval = 5;
    public int lifeTime = 10;

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
        float x = Random.Range(0F, 10F);
        Vector3 startPosition = new Vector3(x, spawnHeight, x) + transform.position;
        GameObject objToAdd = GameObject.Instantiate(obj, startPosition, Quaternion.identity);
        objList.Add(objToAdd);
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
