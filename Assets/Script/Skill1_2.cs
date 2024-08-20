using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Skill1_2 : MonoBehaviour
{
public static List <GameObject> myListObjects = new List<GameObject>();
  
void Start()
{
    //Important note: place your prefabs folder(or levels or whatever) 
    //in a folder called "Resources" like this "Assets/Resources/Prefabs"
    Object[] subListObjects = Resources.LoadAll("Prefabs", typeof(GameObject));

    foreach (GameObject subListObject in subListObjects) 
    {    
        GameObject lo = (GameObject)subListObject;
        myListObjects.Add(lo);
    }
}
}