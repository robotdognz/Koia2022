using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PhoneDeprivation : MonoBehaviour
{
    [SerializeField] private float sanity = 1f;
    [SerializeField] private float depletionTime = 15f;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sanity -= Time.deltaTime / depletionTime;
        sanity = Mathf.Clamp(sanity, 0f, 1f);
        AudioManager.Instance.SetInsanityLevel(1 - sanity);

        //if (ppVolume != null) ppVolume.weight = Remap(sanity, 0f, 0.5f, 1f, 0f);

        PostProcessingManager.Instance.SetInsanityLevel(1 - sanity);
    }

    public void RecoverSanity(float amount)
    {
        sanity += amount;
    }

    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
