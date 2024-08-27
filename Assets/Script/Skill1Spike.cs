using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Skill1Spike : MonoBehaviour
{
    public List<Spike> spikesList = new List<Spike>();
    public float savedTime;
    
    void Start()
    {
       StartCoroutine (up());
    }
    void Update()
    {      
    
    }
    
    IEnumerator up()
    {
        for(int i = 0; i < spikesList.Count; i++)
        //while(i < spikesList.Count)
        {
        spikesList[i].RiseUp();
        Debug.Log("up");
        yield return null;
        }
        for(int i = 0; i < spikesList.Count; i++)
         spikesList[i].FallDown();
         Debug.Log("down");
    }
}
    