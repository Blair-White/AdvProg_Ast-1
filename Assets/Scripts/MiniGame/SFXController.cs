using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public static SFXController instance;
    public AudioClip PopDialog, Mining, Scanning, SwitchMode;
    private AudioSource aud;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            if (instance != this)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        aud = this.GetComponent<AudioSource>();
    }

    public void PlayMining() { aud.PlayOneShot(Mining); }
    public void PlayDialog() { aud.PlayOneShot(PopDialog); }
    public void PlayScanning() { aud.PlayOneShot(Scanning); }
    public void PlaySwitch() { aud.PlayOneShot(SwitchMode); }

    public void SetVolume(float vol) { aud.volume = vol; }
    public void SetVolumeLow() { aud.volume = .05f; }
    public void MuteVolume() { aud.volume = 0.0f; }
    public void SetVolumeMedium() { aud.volume = 0.25f; }

    public void SetVolumeHigh() { aud.volume = 0.5f; }
}
