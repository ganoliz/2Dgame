using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameController gameController;

    public TextMeshProUGUI[] scoreTextes;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        index = 0;
        SetTextColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Setting.Keys.KEY_DOWN) || Input.GetKeyDown(Setting.Keys.KEY_RIGHT))
        {
            index = index + 1 > scoreTextes.Length - 1 ? 0 : index + 1;
            gameController.PlaySw();
        }
        else if (Input.GetKeyDown(Setting.Keys.KEY_UP) || Input.GetKeyDown(Setting.Keys.KEY_LEFT))
        {
            index = index - 1 < 0 ? scoreTextes.Length - 1 : index - 1;
            gameController.PlaySw();
        }
        else if (Input.GetKeyDown(Setting.Keys.KEY_ABILITY))
        {
            index = scoreTextes.Length - 1;
            gameController.PlaySw();
        }

        SetTextColor();

        if (Input.GetKeyDown(Setting.Keys.KEY_JUMP))
        {
            gameController.PlaySe();
            switch (index)
            {
                case 0:
                    gameController.Resume();
                    break;
                case 1:
                    SceneManager.LoadScene("GameScene");
                    break;
                case 2:
                    SceneManager.LoadScene("MainMenu");
                    break;
                default:
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
