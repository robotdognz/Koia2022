using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    public static PostProcessingManager Instance;

    [SerializeField] private PostProcessVolume insanityVolume;
    [SerializeField] private PostProcessVolume blurVolume;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameState(bool onPhone) => StartCoroutine(SetWeight(blurVolume, onPhone ? 1f : 0f));

    public void SetInsanityLevel(float level)
    {
        StartCoroutine(SetWeight(insanityVolume, level));
    }

    private IEnumerator SetWeight(PostProcessVolume volume, float targetWeight)
    {
        float transition = 0f;
        float initialWeight = volume.weight;

        while (transition < 1f)
        {
            transition += 0.01f;
            volume.weight = Mathf.Lerp(initialWeight, targetWeight, transition);
            yield return null;
        }
    }
}
