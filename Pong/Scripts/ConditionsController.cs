using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConditionsController : MonoBehaviour
{
    public TMP_Dropdown pointsDropdown;
    public TMP_Dropdown colorDropdown;

    public void SetVictoryConditions() {
        int points = int.Parse(pointsDropdown.captionText.text);
        PlayerPrefs.SetInt("maxPoints", points);
    }

    public void SetColorPalette() {
        var palette = colorDropdown.captionText.text;
        PlayerPrefs.SetString("pongStyleCode", palette);
    }
}
