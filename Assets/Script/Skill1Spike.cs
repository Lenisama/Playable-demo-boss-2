using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Skill1Spike : MonoBehaviour
{
    public List<Spike> spikesList = new List<Spike>();
    public float timeBetweenSpikes = 0.1f;

    public void RaiseSpikes(float timeBetween)
    {
	    StartCoroutine(RaiseSpikesRoutine(timeBetween));
    }
    
    IEnumerator RaiseSpikesRoutine(float timeBetween)
    {
	    for (int i = 0; i < spikesList.Count; i++)
	    {
		    spikesList[i].RiseUp();
		    Debug.Log("up");
		    yield return new WaitForSeconds(timeBetween);
	    }
    }
}
    