using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioMixer MasterMixer;
    [SerializeField] private AudioMixerSnapshot OffPhoneSnapshot;
    [SerializeField] private AudioMixerSnapshot OnPhoneSnapshot;

    [SerializeField] private AudioSource uiAudioSource;
    [SerializeField] private AudioClip phoneOpenClip;
    [SerializeField] private AudioClip phoneCloseClip;

    [SerializeField] private AudioSource insanityAudioSource;

    [SerializeField] private AudioSource likeAudioSource;

    [SerializeField] private float encouragementChance = 0.15f;
    [SerializeField] private AudioSource encouragementAudioSource;
    [SerializeField] private AudioClip[] encouragementAudioClips;

    private int encouragementCounter;

    public bool OnPhone;

    [SerializeField] private bool debug = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        encouragementCounter = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (debug) { 
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SetGameState(!OnPhone);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayLikeSound();
            }
        }
    }

    public void SetGameState(bool _onPhone)
    {
        OnPhone = _onPhone;
        AudioMixerSnapshot targetSnapshot = OnPhone ? OnPhoneSnapshot : OffPhoneSnapshot;
        AudioClip transitionClip = OnPhone ? phoneOpenClip : phoneCloseClip;
        targetSnapshot.TransitionTo(0.5f);
        uiAudioSource.PlayOneShot(transitionClip);
    }

    
    public void SetInsanityLevel(float level)
    {
        float lpFreq = Remap(level, 0.5f, 1f, 22000f, 1000f);
        float reverbAmount = Remap(level, 0.5f, 1f, -10000f, 0f);

        insanityAudioSource.volume = Remap(level, 0.5f, 1f, 0f, 1f);
        MasterMixer.SetFloat("LPFreq", lpFreq);
        MasterMixer.SetFloat("ReverbAmount", reverbAmount);
    }
    

    public void PlayLikeSound()
    {
        likeAudioSource.Play();

        encouragementCounter -= 1;
        if (encouragementCounter <= 0) PlayEncouragementSound();
    }

    public void PlayEncouragementSound()
    {
        encouragementCounter = Random.Range(1, 10);
        int clipIndex = Random.Range(0, encouragementAudioClips.Length);
        encouragementAudioSource.clip = encouragementAudioClips[clipIndex];
        encouragementAudioSource.PlayDelayed(0.05f);
    }

    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
