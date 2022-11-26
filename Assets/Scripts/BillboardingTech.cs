using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardingTech : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    private Camera Cam1stPerson;

    void Start()
    {
        Cam1stPerson = Camera.main;

        if (sprites != null && sprites.Length > 0)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
