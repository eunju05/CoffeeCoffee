using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void GameStart()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.UIClick);
        SceneManager.LoadScene("Main");
    }
    public void GameQuit()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.UIClick);
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
