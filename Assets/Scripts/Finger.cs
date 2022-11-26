using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : MonoBehaviour
{
    [SerializeField] private Transform phone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0);
        transform.position = mousePos + phone.localPosition;
    }

    
}
