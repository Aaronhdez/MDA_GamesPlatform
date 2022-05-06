using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StyleControllerPong : MonoBehaviour
{
    public string styleCode;
    public List<GameObject> objectsInColor1;
    public List<GameObject> buttonsInColor1;
    public List<TextMeshProUGUI> textsInColor1;
    public Camera camera;
    private Dictionary<string, List<Color>> colorCodes;

    public void SetColorStyle() {
        camera.clearFlags = CameraClearFlags.SolidColor;
        colorCodes = ColorPalettes.Instance();
        List<Color> palette = colorCodes[PlayerPrefs.GetString("pongStyleCode")];
        SetColorsFrom(palette);
    }

    private void SetColorsFrom(List<Color> palette) {
        SetBackgroundColorTo(palette[0]);
        SetTextColorTo(palette[1]);
        SetObjectColorsTo(palette[1]);
        SetButtonsColorsTo(palette[1]);
    }

    private void SetTextColorTo(Color color) {
        foreach (TextMeshProUGUI textField in textsInColor1) {
            textField.color = color;
        }
    }

    private void SetButtonsColorsTo(Color color) {
        foreach (GameObject gameObject in buttonsInColor1) {
            gameObject.GetComponent<Image>().color = color;
        }
    }

    private void SetObjectColorsTo(Color color) {
        foreach (GameObject gameObject in objectsInColor1) {
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
    }

    private void SetBackgroundColorTo(Color color) {
        camera.backgroundColor = color;
    }
}
