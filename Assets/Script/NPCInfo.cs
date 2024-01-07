using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInf : MonoBehaviour
{
    public GameManager gameManager;
    public ButtonControl buttonControl;

    public float maxtime;
    public float time;
    public float Hp;
    public int Score;
    public Sprite[] emotion = new Sprite[3];
    public Slider timerSlider;

    public bool timerstop = false;

    private SpriteRenderer npcSR;
    private Animator anim;
    private void Awake()
    {
        npcSR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        
        time = maxtime;
        timerSlider.maxValue = maxtime;
        timerSlider.value = time;
    }

    private void Update()
    {
        timerstop = buttonControl.isPause;
        if (timerstop == false)
        {
            time -= Time.deltaTime;
            timerSlider.value = time;
            if (time <= maxtime * 0.5)
            {
                npcSR.sprite = emotion[2];
            }
            if (time <= 0)
            {
                gameManager.HpMinus(Hp);
                Destroy(gameObject);
            }
        }
    }

   
}
