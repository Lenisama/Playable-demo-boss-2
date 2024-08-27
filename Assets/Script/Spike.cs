using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Spike : MonoBehaviour
{
    public float savedTime;
    public float speed = 50;
    public float distance = 2;
    // Start is called before the first frame update
    public void RiseUp()
    {
        StartCoroutine(Rise());
    }
    public IEnumerator Rise()
    {
        Vector3 start = transform.position;
        Vector3 end = start + new Vector3(0, distance, 0);
        while (Vector3.Distance(transform.position, end) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, end, speed * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(FallDown());
    }

    public IEnumerator FallDown()
    {
        Vector3 start = transform.position;
        Vector3 end = start - new Vector3(0, distance, 0);
        while (Vector3.Distance(transform.position, end) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, end, speed * Time.deltaTime);
            yield return null;
        }
    }
}