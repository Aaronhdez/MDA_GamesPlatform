using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerPong : MonoBehaviour { 

    [SerializeField] public AudioSource victorySound;
    [SerializeField] private AudioSource pointSound;

    public void PlayVictorySound() {
        victorySound.Play();
    }

    public void PlayPointSound() {
        pointSound.Play();
    }
}
