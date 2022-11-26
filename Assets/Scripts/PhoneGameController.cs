using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneGameController : MonoBehaviour
{
    [SerializeField] Camera phoneGameCamera;
    [SerializeField] GameObject pointer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputMouse(Vector2 mouse)
    {
        // move pointer to mouse
        // Debug.Log("screen pos: "+ mouse + ", world pos: " + phoneGameCamera.ScreenToWorldPoint(mouse));
        pointer.transform.position = phoneGameCamera.ViewportToWorldPoint(mouse) + Vector3.forward;
    }
}
