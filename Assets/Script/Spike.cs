using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Spike : MonoBehaviour
{
    public float speed = 50;
    // Start is called before the first frame update
    public void RiseUp()
    {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime);
    }
    public void FallDown()
    {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime);
    }
}