using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConditionsController : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public void SetVictoryConditions() {
        int points = int.Parse(dropdown.captionText.text);
        PlayerPrefs.SetInt("maxPoints", points);
        Debug.Log(PlayerPrefs.GetInt("maxPoints"));
    }
}
