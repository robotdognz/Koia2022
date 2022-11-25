using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardingTech : MonoBehaviour
{

    private Camera Cam1stPerson;

    // Start is called before the first frame update
    void Start()
    {
        Cam1stPerson = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
