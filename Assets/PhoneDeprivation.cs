using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneDeprivation : MonoBehaviour
{
    [SerializeField] private float sanity = 1f;
    [SerializeField] private float depletionTime = 15f;

    // Update is called once per frame
    void Update()
    {
        sanity -= Time.deltaTime / depletionTime;
        sanity = Mathf.Clamp(sanity, 0f, 1f);
        AudioManager.Instance.SetInsanityLevel(1 - sanity);
    }

    public void RecoverSanity(float amount)
    {
        sanity += amount;
    }
}
