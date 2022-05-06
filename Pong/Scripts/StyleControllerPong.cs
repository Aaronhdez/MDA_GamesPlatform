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

    public void Start() {
        colorCodes = new Dictionary<string, List<Color>>();
        colorCodes.Add("default", 
            new List<Color> { 
                Color.black,
                Color.white
            }
        );
        colorCodes.Add("space",
            new List<Color> {
                Color.black,
                new Color(0.5f, 0.85f, 1f, 1f),
            }
        );
        colorCodes.Add("matrix",
            new List<Color> {
                Color.black,
                Color.green,
            }
        );
        colorCodes.Add("protanophia", // -> R
            new List<Color> {
                new Color(0.03f, 0.33f, 0.43f, 1f),
                new Color(0.74f, 0.66f, 0f, 1f)
            }
        );
        colorCodes.Add("deuteranophia", // -> G
            new List<Color> {
                new Color(0.08f, 0.54f, 0.74f, 1f),
                new Color(0.74f, 0.66f, 0f, 1f)
            }
        );
        colorCodes.Add("trianophia", // -> B
            new List<Color> {
                new Color(0f, 0.40f, 0.40f, 1f),
                new Color(1f, 0.40f, 0.40f, 1f)
            }
        );
    }

    public void SetColorStyle() {
        camera.clearFlags = CameraClearFlags.SolidColor;
        PlayerPrefs.SetString("styleCode", "matrix");
        List<Color> palette = colorCodes[PlayerPrefs.GetString("styleCode")];
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
