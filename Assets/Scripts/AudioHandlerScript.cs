using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandlerScript : MonoBehaviour
{

    public AudioClip musicRussianLoop;
    public AudioClip musicElectronicLoop;
    public AudioClip musicNewsHead;
    public AudioClip musicNewsLoop;
    private AudioSource audioSource;
    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
 
    public void PlayMusic(bool loop = true) {
        audioSource.loop = loop;
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
 
    public void StopMusic() {
        audioSource.Stop();
    }

    public void SetClip(AudioClip clip, bool start = true, bool loop = true) {
        StopMusic();
        audioSource.clip = clip;
        if (start) {
            PlayMusic(loop);
        }
    }

    public void startRussianMusic() {
        SetClip(musicRussianLoop, true);
    }
    
    public void startElectronicMusic() {
        SetClip(musicElectronicLoop, true);
    }
    
    public void startNewsHeadMusic() {
        SetClip(musicNewsHead, true);
    }
    
    public void startNewsLoopMusic() {
        SetClip(musicNewsLoop, true);
    }


}

