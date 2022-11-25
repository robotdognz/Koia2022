using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardMoveSpeed = 2;
    [SerializeField] int movementZones = 3;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate() {
        transform.Translate(Vector3.forward * forwardMoveSpeed * Time.fixedDeltaTime);
    }
}
