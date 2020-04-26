using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyMenu : MonoBehaviour
{
    MenuController menuController;

    public TextMeshProUGUI[] scoreTextes;
    public Image[] images;
    private int index;
    private bool isLock;

    public enum SetBtnState
    {
        Wait,
        Lock,
        Change
    }

    private SetBtnState setBtnState;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuController>();
        index = 0;
        isLock = false;
        setBtnState = SetBtnState.Wait;
        SetTextColor();
        SetKeyBoardSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLock)
        {
            if (Input.GetKeyDown(Setting.Keys.KEY_DOWN) || Input.GetKeyDown(Setting.Keys.KEY_RIGHT))
            {
                index = index + 1 > scoreTextes.Length - 1 ? 0 : index + 1;
                menuController.PlaySw();
            }
            else if (Input.GetKeyDown(Setting.Keys.KEY_UP) || Input.GetKeyDown(Setting.Keys.KEY_LEFT))
            {
                index = index - 1 < 0 ? scoreTextes.Length - 1 : index - 1;
                menuController.PlaySw();
            }
            else if (Input.GetKeyDown(Setting.Keys.KEY_ABILITY))
            {
                index = scoreTextes.Length - 1;
                menuController.PlaySw();
            }
        }
        
        SetTextColor();

        if(Input.GetKeyDown(Setting.Keys.KEY_JUMP))
        {
            menuController.PlaySe();
            if (index == 7)
            {
                Setting.Keys.Default();
                SetKeyBoardSprite();
            }
            else if(index == 8)
            {
                menuController.SetMenuActive("OptionMenu");
            }
            else if(setBtnState == SetBtnState.Wait)
            {
                isLock = true;
                setBtnState = SetBtnState.Lock;
            }
        }

        if(setBtnState == SetBtnState.Lock)
        {
            images[index].enabled = false;
            setBtnState = SetBtnState.Change;
        }
        else if(setBtnState == SetBtnState.Change)
        {
            foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode))){
                if (Input.GetKeyDown(kcode))
                {
                    menuController.PlaySe();
                    switch (index)
                    {
                        case 0:
                            Setting.Keys.KEY_UP = kcode;
                            break;
                        case 1:
                            Setting.Keys.KEY_DOWN = kcode;
                            break;
                        case 2:
                            Setting.Keys.KEY_LEFT = kcode;
                            break;
                        case 3:
                            Setting.Keys.KEY_RIGHT = kcode;
                            break;
                        case 4:
                            Setting.Keys.KEY_JUMP = kcode;
                            break;
                        case 5:
                            Setting.Keys.KEY_ABILITY = kcode;
                            break;
                        case 6:
                            Setting.Keys.KEY_CHANGEMODE = kcode;
                            break;
                        default:
                            break;
                    }
                    SetKeyBoardSprite();
                    setBtnState = SetBtnState.Wait;
                    images[index].enabled = true;
                    isLock = false;
                    break;
                }
            }
        }
    }

    void SetTextColor()
    {
        for (int i = 0; i < scoreTextes.Length; i++)
        {
            scoreTextes[i].color = Color.white;
        }

        scoreTextes[index].color = Color.red;
    }

    void SetKeyBoardSprite()
    {
        images[0].sprite = PublicObj.Template.GetSprite("KB_" + Setting.Keys.KEY_UP.ToString());
        images[1].sprite = PublicObj.Template.GetSprite("KB_" + Setting.Keys.KEY_DOWN.ToString());
        images[2].sprite = PublicObj.Template.GetSprite("KB_" + Setting.Keys.KEY_LEFT.ToString());
        images[3].sprite = PublicObj.Template.GetSprite("KB_" + Setting.Keys.KEY_RIGHT.ToString());
        images[4].sprite = PublicObj.Template.GetSprite("KB_" + Setting.Keys.KEY_JUMP.ToString());
        images[5].sprite = PublicObj.Template.GetSprite("KB_" + Setting.Keys.KEY_ABILITY.ToString());
        images[6].sprite = PublicObj.Template.GetSprite("KB_" + Setting.Keys.KEY_CHANGEMODE.ToString());
    }
}
