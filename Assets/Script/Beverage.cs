using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Beverage : MonoBehaviour
{
    public ButtonControl buttonControl;
    public RecipeBook recipeBook;
    public Sprite[] coffee = new Sprite[11];
    public Sprite[] icon = new Sprite[11];
    public GameObject[] order = new GameObject[5];
    public string[] ordername = new string[5];

    public GameObject Menu;

    int i = 0;
    bool cold = true;
    bool serving = false;

    private SpriteRenderer sr_Menu;
    private void Awake()
    {
        sr_Menu = Menu.GetComponent<SpriteRenderer>();
        ordername[0] = null;
    }

    private void Start()
    {
        sr_Menu.sprite = null;
    }
    private void Update()
    {
        if (i < 5 && recipeBook.isBook == false && buttonControl.isPause == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                if (hit.collider != null && hit.collider.name == "CH")
                {
                    if (cold)
                    {
                        cold = false;

                        hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color32(162, 20, 70, 255);
                    }
                    else
                    {
                        cold = true;
                        hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color32(37, 108, 192, 255);
                    }
                    Debug.Log(hit.collider.name);
                }

                else if (hit.collider != null && hit.collider.name != "CH")
                {
                    {
                        if (hit.collider.name == "coffee")
                        {
                            order[i].GetComponent<SpriteRenderer>().sprite = icon[7];
                        }                       
                        else if (hit.collider.name == "milk")
                            order[i].GetComponent<SpriteRenderer>().sprite = icon[2];
                        else if (hit.collider.name == "steam")
                            order[i].GetComponent<SpriteRenderer>().sprite = icon[8];
                        else if (hit.collider.name == "ice")
                            order[i].GetComponent<SpriteRenderer>().sprite = icon[1];
                        else if (hit.collider.name == "tea")
                            order[i].GetComponent<SpriteRenderer>().sprite = icon[0];
                        else if (hit.collider.name == "choco")
                            order[i].GetComponent<SpriteRenderer>().sprite = icon[3];
                        else if (hit.collider.name == "strawberry")
                            order[i].GetComponent<SpriteRenderer>().sprite = icon[4];
                        else if (hit.collider.name == "grind")
                            order[i].GetComponent<SpriteRenderer>().sprite = icon[5];
                        else if (hit.collider.name == "cream")
                            order[i].GetComponent<SpriteRenderer>().sprite = icon[6];

                        ordername[i] = hit.collider.name;                                                

                        if (hit.collider.name == "water")
                        {
                            if (cold)
                            {
                                order[i].GetComponent<SpriteRenderer>().sprite = icon[9];
                                ordername[i] = "coldwater";
                            }
                            else
                            {
                                order[i].GetComponent<SpriteRenderer>().sprite = icon[10];
                                ordername[i] = "hotwater";
                            }
                        }
                        Debug.Log(ordername[i]);
                        i++;
                    }
                }                

                
            }
        }
    }
    public void OrderReset()
    {
        Debug.Log(i);
        for(int j = 0; j <= 4; j++)
        {
            order[j].GetComponent<SpriteRenderer>().sprite = null;
            ordername[j] = null;
        }
        i = 0;
    }

    public void ServeReset()
    {
        serving = false;
        Menu.GetComponent<SpriteRenderer>().sprite = null;
    }

    public void Making()
    {
        if (ordername[0] != null && serving == false)
        {
            serving = true;
            //아메리카노
            if (ordername[0] == "coffee" && ordername[1] == "hotwater")
            {
                sr_Menu.sprite = coffee[0];
            }
            //아이스아메리카노
            else if (ordername[0] == "coffee" && ordername[1] == "coldwater" && ordername[2] == "ice")
            {
                sr_Menu.sprite = coffee[1];
            }

            //카페라떼
            else if (ordername[0] == "coffee" && ordername[1] == "steam")
            {
                sr_Menu.sprite = coffee[2];
            }
            //아이스카페라떼
            else if (ordername[0] == "coffee" && ordername[1] == "milk" && ordername[2] == "ice")
            {
                sr_Menu.sprite = coffee[3];
            }

            //카페모카
            else if (ordername[0] == "coffee" && ordername[1] == "choco" && ordername[2] == "steam" && ordername[3] == "cream")
            {
                sr_Menu.sprite = coffee[4];
            }
            //아이스카페모카
            else if (ordername[0] == "coffee" && ordername[1] == "choco" && ordername[2] == "milk" && ordername[3] == "ice" && ordername[4] == "cream")
            {
                sr_Menu.sprite = coffee[5];
            }

            //딸기스무디
            else if (ordername[0] == "strawberry" && ordername[1] == "ice" && ordername[2] == "milk" && ordername[3] == "grind")
            {
                sr_Menu.sprite = coffee[6];
            }
            //초코스무디
            else if (ordername[0] == "choco" && ordername[1] == "ice" && ordername[2] == "milk" && ordername[3] == "grind")
            {
                sr_Menu.sprite = coffee[7];
            }

            //녹차라떼
            else if (ordername[0] == "tea" && ordername[1] == "steam")
            {
                sr_Menu.sprite = coffee[8];
            }
            //아이스녹차라떼
            else if (ordername[0] == "tea" && ordername[1] == "hotwater" && ordername[2] == "milk" && ordername[3] == "ice")
            {
                sr_Menu.sprite = coffee[9];
            }

            //이상한 음료
            else
            {
                sr_Menu.sprite = coffee[10];
            }

            OrderReset();
        }
    }
}
