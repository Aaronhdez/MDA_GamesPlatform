using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour {
    public void LoadPongScene() {
        SceneManager.LoadScene("MainScenePong");
    }

    public void LoadArkanoidsScene() {

    }

    public void LoadBreakoutScene() {
        SceneManager.LoadScene("MainSceneBreakout");
    }
}
