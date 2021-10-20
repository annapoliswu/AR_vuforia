using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Falling Object")]
public class FallingObjectData : ScriptableObject {
    public GameObject prefab;
    public string type;
    public int points;
}
