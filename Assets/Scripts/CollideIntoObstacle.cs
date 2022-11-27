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
            AudioManager.Instance.PlayObstacleHitSound();
            //Application.Quit();//for now
        }

        if (crash.gameObject.tag == "End Point")
        {
            Debug.Log("My friend! You are here!");
            AudioManager.Instance.PlayCourseCompleteSound();
            FindObjectOfType<PlayerMovement>().DisablePlayer();
            FindObjectOfType<PhoneDeprivation>().RecoverSanity(1f);
            //Application.Quit();//for now
        }



    }
}
