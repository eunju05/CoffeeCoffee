using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public ButtonControl buttonControl;
    public GameObject _camera;
    [SerializeField]
    public Slider HpBar;
    public TextMeshProUGUI Hp;


    public float CurHp = 30;
    public float MaxHp = 100;
    public bool isChange = false;

    // Start is called before the first frame update
    void Start()
    {
        HpBar.value = CurHp / MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        //일시정지
        if (buttonControl.isPause == false)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                isChange = true;
                if (_camera.transform.position.x == 0)
                {
                    _camera.transform.Translate(new Vector2(10.8f, 0));
                }
                else
                {
                    _camera.transform.Translate(new Vector2(-10.8f, 0));
                }
            }
        }
    }

    public void HpMinus(float _damage)
    {
        CurHp -= _damage;
        HpBar.value = CurHp / MaxHp;
        Hp.text = $"{CurHp}/100";
    }
}
