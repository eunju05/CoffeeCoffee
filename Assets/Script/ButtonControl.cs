using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public GameObject PausePanel;
    public NPCInf nPCInf;

    public bool isPause = false;

    //일시정지
    public void GamePause()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.UIClick);
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
            //nPCInf.timerstop = false;
            PausePanel.SetActive(isPause);
        }
        else
        {
            Time.timeScale = 0;
            isPause = true;
            //nPCInf.timerstop = true;
            PausePanel.SetActive(isPause);
        }
    }
}
