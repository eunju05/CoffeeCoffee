using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public GameObject RecipeBookPanel;
    public GameObject page1;
    public GameObject page2;
    public int page = 1;
    public bool isBook = false;

    //·¹½ÃÇÇºÏ
    public void RecipeBookOpen()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.UIClick);
        RecipeBookPanel.SetActive(true);
        isBook = true;
    }

    public void RecipeBookPageChange()
    {
        if(page == 1)
        {
            page++;
            page1.SetActive(false);
            page2.SetActive(true);
        }
        else if (page == 2)
        {
            page--;
            page2.SetActive(false);
            page1.SetActive(true);
        }
        Debug.Log(page);
    }

    public void PageClose()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.UIClick);
        isBook = false;
        RecipeBookPanel.SetActive(false);
    }
}
