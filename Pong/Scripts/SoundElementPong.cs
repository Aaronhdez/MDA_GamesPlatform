using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundElementPong : MonoBehaviour {
    
    [SerializeField] public AudioSource pointSound;
    public void PlaySound() {
        pointSound.Play();
    }

}
