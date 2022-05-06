using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPalettes {

    private static Dictionary<string, List<Color>> instance;

    public static Dictionary<string, List<Color>> Instance() {
        if (instance == null) {
            LoadDictionary();
        }
        return instance;
    }

    private static void LoadDictionary() {
        instance = new Dictionary<string, List<Color>>();
        instance.Add("default",
            new List<Color> {
                Color.black,
                Color.white
            }
        );
        instance.Add("space",
            new List<Color> {
                Color.black,
                new Color(0.5f, 0.85f, 1f, 1f),
            }
        );
        instance.Add("matrix",
            new List<Color> {
                Color.black,
                Color.green,
            }
        );
        instance.Add("protanophia", // -> R
            new List<Color> {
                new Color(0.03f, 0.33f, 0.43f, 1f),
                new Color(0.74f, 0.66f, 0f, 1f)
            }
        );
        instance.Add("deuteranophia", // -> G
            new List<Color> {
                new Color(0.08f, 0.54f, 0.74f, 1f),
                new Color(0.74f, 0.66f, 0f, 1f)
            }
        );
        instance.Add("trianophia", // -> B
            new List<Color> {
                new Color(0f, 0.40f, 0.40f, 1f),
                new Color(1f, 0.40f, 0.40f, 1f)
            }
        );
    }
}
