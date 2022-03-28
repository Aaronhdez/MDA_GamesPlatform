using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour {
    
    public void LoadPongPVPScene() {
        PlayerPrefs.SetString("mode", "pvp");
        SceneManager.LoadScene("MainScenePong");
    }

    public void LoadPongPVEScene() {
        PlayerPrefs.SetString("mode", "pve");
        SceneManager.LoadScene("MainScenePong");
    }

    public void LoadMenuPongScene() {
        SceneManager.LoadScene("MenuScenePong");
    }

    public void LoadOptionsPongScene() {
        SceneManager.LoadScene("OptionsMenuPong");
    }

    public void LoadArkanoidsScene() {
        SceneManager.LoadScene("MainSceneArkanoid");
    }

    public void LoadBreakoutScene() {
        SceneManager.LoadScene("MainSceneBreakout");
    }
}
