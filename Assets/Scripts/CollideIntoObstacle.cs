using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideIntoObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider crash)
    {
        if (crash.gameObject.tag == "Obstacle")
        {
            Debug.Log("You crashed into something and dropped your phone.This is the end of your journey.");
        }
    }
}
