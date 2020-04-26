using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    MenuController menuController;

    public TextMeshProUGUI[] scoreTextes;
    private int index; // for  mainmenu index

    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuController>();
        index = 0;
        SetTextColor();
    }

    // Update is called once per frame
    void Update()
    {
        // 主畫面
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

        SetTextColor();

        if (Input.GetKeyDown(Setting.Keys.KEY_JUMP))
        {
            menuController.PlaySe();
            switch (index)
            {
                // 開始遊戲
                case 0:
                    SceneManager.LoadScene("GameScene");
                    break;
                // 遊戲選項
                case 1:
                    menuController.SetMenuActive("OptionMenu");
                    break;
                // 離開遊戲
                case 2:
                    Application.Quit();
                    break;
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
}
