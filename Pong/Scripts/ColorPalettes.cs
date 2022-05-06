using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPalettes {

    private static Dictionary<string, List<Color>> instance;

    public static Dictionary<string, List<Color>> Instance {
        get {
            if (instance == null) {
                LoadDictionary();
            }
            return instance;
        }
    }

    private static void LoadDictionary() {
        instance = new Dictionary<string, List<Color>>();
        instance.Add("Default",
            new List<Color> {
                Color.black,
                Color.white
            }
        );
        instance.Add("Space",
            new List<Color> {
                Color.black,
                new Color(0.5f, 0.85f, 1f, 1f),
            }
        );
        instance.Add("Matrix",
            new List<Color> {
                Color.black,
                Color.green,
            }
        );
        instance.Add("Colorblind (R)", // -> R
            new List<Color> {
                new Color(0.03f, 0.33f, 0.43f, 1f),
                new Color(0.74f, 0.66f, 0f, 1f)
            }
        );
        instance.Add("Colorblind (G)", // -> G
            new List<Color> {
                new Color(0.08f, 0.54f, 0.74f, 1f),
                new Color(0.74f, 0.66f, 0f, 1f)
            }
        );
        instance.Add("Colorblind (B)", // -> B
            new List<Color> {
                new Color(0f, 0.40f, 0.40f, 1f),
                new Color(1f, 0.40f, 0.40f, 1f)
            }
        );
    }
}
