using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PhoneDeprivation : MonoBehaviour
{
    public float sanity = 1f;
    [SerializeField] private float depletionTime = 15f;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AudioManager.Instance.OnPhone && playerMovement.isMoving) sanity -= Time.deltaTime / depletionTime;
        sanity = Mathf.Clamp(sanity, 0f, 1f);
        AudioManager.Instance.SetInsanityLevel(1 - sanity);

        //if (ppVolume != null) ppVolume.weight = Remap(sanity, 0f, 0.5f, 1f, 0f);

        PostProcessingManager.Instance.SetInsanityLevel(Remap(sanity, 0f, 0.66f, 1f, 0f));
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
