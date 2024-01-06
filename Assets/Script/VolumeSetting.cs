using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public Slider bgm_silder;
    public Slider sfx_silder;

    public void Init()
    {
        bgm_silder.value = AudioManager.instance.bgmVolume;
        sfx_silder.value = AudioManager.instance.sfxVolume;
    }
    public void SetBgmVolume(float volume)
    {
        AudioManager.instance.bgmPlayer.volume = volume;
        AudioManager.instance.bgmVolume = volume;       
    }

    public void SetSfxVolume(float volume)
    {
        for (int i = 0; i < AudioManager.instance.sfxPlayers.Length; i++)
        {
            AudioManager.instance.sfxPlayers[i].volume = volume;
            AudioManager.instance.sfxVolume = volume;
        }
    }
}
