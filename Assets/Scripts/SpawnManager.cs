using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;
    public GameObject obj;

    public int spawnHeight = 25;
    public int spawnRadius = 5;

    public int spawnInterval = 3;
    public int holdBeforeDrop = 4;
    public int lifeTime = 20;



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
        float angle = Random.Range(0, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * spawnRadius;
        float z = Mathf.Cos(angle) * spawnRadius;

        Vector3 startPosition = new Vector3(x, spawnHeight, z) + transform.position; //make relative posn
        GameObject objToAdd = GameObject.Instantiate(obj, startPosition, Quaternion.identity);


        obj.GetComponent<Rigidbody>().useGravity = false;
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
