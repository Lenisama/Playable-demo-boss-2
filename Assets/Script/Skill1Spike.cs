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
        
    }
    void Update()
    {        
        savedTime = Time.time;
        if(Time.time > 0.9 && Time.time <= 1)
        {
        spikesList[0].RiseUp();
        }
        else if (Time.time > 1 && Time.time <= 1.1)
        {
            spikesList[1].RiseUp();
        }
        else if (Time.time > 1.1 && Time.time <= 1.2)
        {
            spikesList[2].RiseUp();
            spikesList[0].FallDown();
        }
        else if (Time.time > 1.2 && Time.time <= 1.3)
        {
            spikesList[3].RiseUp();
            spikesList[1].FallDown();
        }
        else if (Time.time > 1.3 && Time.time <= 1.4)
        {
            spikesList[4].RiseUp();
            spikesList[2].FallDown();
        }
         else if (Time.time > 1.4 && Time.time <= 1.5)
        {
            spikesList[5].RiseUp();
            spikesList[3].FallDown();
        }
        else if (Time.time > 1.5 && Time.time <= 1.6)
        {
            spikesList[6].RiseUp();
            spikesList[4].FallDown();
        }
        else if (Time.time > 1.6 && Time.time <= 1.7)
        {
            spikesList[7].RiseUp();
            spikesList[5].FallDown();
        }
        else if (Time.time > 1.7 && Time.time <= 1.8)
        {
            spikesList[8].RiseUp();
            spikesList[6].FallDown();
        }
         else if (Time.time > 1.8 && Time.time <= 1.9)
        {
            spikesList[9].RiseUp();
            spikesList[7].FallDown();
        }
        else if (Time.time > 1.9 && Time.time <= 2)
        {
            spikesList[10].RiseUp();
            spikesList[8].FallDown();
        }
        else if (Time.time > 2.1 && Time.time <= 2.2)
        {
            spikesList[11].RiseUp();
            spikesList[9].FallDown();
        }
        else if (Time.time > 2.2 && Time.time <= 2.3)
        {
            spikesList[12].RiseUp();
            spikesList[10].FallDown();
        }
        else if (Time.time > 2.3 && Time.time <= 2.4)
        {
            spikesList[13].RiseUp();
            spikesList[11].FallDown();
        }
        else if (Time.time > 2.4 && Time.time <= 2.5)
        {
            spikesList[14].RiseUp();
            spikesList[12].FallDown();
        }
        else if (Time.time > 2.5 && Time.time <= 2.6)
        {
            spikesList[15].RiseUp();
            spikesList[13].FallDown();
        }
        else if (Time.time > 2.6 && Time.time <= 2.7)
        {
            spikesList[16].RiseUp();
            spikesList[14].FallDown();
        }
         else if (Time.time > 2.7 && Time.time <= 2.8)
        {
            spikesList[17].RiseUp();
            spikesList[15].FallDown();
        }
        else if (Time.time > 2.8 && Time.time <= 2.9)
        {
            spikesList[18].RiseUp();
            spikesList[16].FallDown();
        }
        else if (Time.time > 2.9 && Time.time <= 3)
        {
            spikesList[19].RiseUp();
            spikesList[17].FallDown();
        }
        else if (Time.time > 3 && Time.time <= 3.1)
        {
            spikesList[20].RiseUp();
            spikesList[18].FallDown();
        }
         else if (Time.time > 3.1 && Time.time <= 3.2)
        {
            spikesList[21].RiseUp();
            spikesList[19].FallDown();
        }
        else if (Time.time > 3.2 && Time.time <= 3.3)
        {
            spikesList[22].RiseUp();
            spikesList[20].FallDown();
        }
        else if (Time.time > 3.3 && Time.time <= 3.4)
        {
            spikesList[23].RiseUp();
            spikesList[21].FallDown();
        }
        else if (Time.time > 3.4 && Time.time <= 3.5)
        {
            spikesList[22].FallDown();
        }
        else if (Time.time > 3.5 && Time.time <= 3.6)
        {
            spikesList[23].FallDown();
        }
    }
}
    