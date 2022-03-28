using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedControllerPong : MonoBehaviour
{
    public Slider slider;

    public void UpdateSpeedFactor() {
        var speed = 1 + (((float) slider.value / 10f) * 0.2f);
        PlayerPrefs.SetFloat("speed", speed);
    }
}
