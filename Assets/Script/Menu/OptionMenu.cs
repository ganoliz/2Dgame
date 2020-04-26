using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class OptionMenu : MonoBehaviour
{
    // Start is called before the first frame update

    MenuController menuController;
    private int index;
    public TextMeshProUGUI[] scoreTextes;
    public TextMeshProUGUI[] volumeTextes;

    void Start()
    {
        menuController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuController>();
        index = 0;
        SetTextColor();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Setting.Keys.KEY_DOWN) )
        {
            index = index + 1 > scoreTextes.Length - 1 ? 0 : index + 1;
            menuController.PlaySw();
        }
        else if (Input.GetKeyDown(Setting.Keys.KEY_UP))
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

        if(index == 0)
        {
            SetBGMVolume();
        }
        else if(index == 1)
        {
            SetEffectVolume();
        }

        if (Input.GetKeyDown(Setting.Keys.KEY_JUMP))
        {
            menuController.PlaySe();
            switch (index)
            {
                case 2:
                    menuController.SetMenuActive("KeyMenu"); break;
                case 3:
                    Setting.Volume.Default();
                    break;
                case 4:
                    menuController.SetMenuActive("MainMenu");
                    break;
            }
        }

        volumeTextes[0].text = Setting.Volume.VOLUME_BGM.ToString() + "%";
        volumeTextes[1].text = Setting.Volume.VOLUME_EFFECT.ToString() + "%";
    }

    void SetTextColor()
    {
        for (int i = 0; i < scoreTextes.Length; i++)
        {
            scoreTextes[i].color = Color.white;
        }
        scoreTextes[index].color = Color.red;

        for(int i = 0; i < volumeTextes.Length; i++)
        {
            volumeTextes[i].color = Color.white;
        }
    }

    void SetBGMVolume()
    {
        int volume = Setting.Volume.VOLUME_BGM;
        if (Input.GetKeyDown(Setting.Keys.KEY_LEFT))
        {
            volume = volume - 5 < 0 ? 0 : volume - 5;
        }
        else if (Input.GetKeyDown(Setting.Keys.KEY_RIGHT))
        {
            volume = volume + 5f > 100 ? 100 : volume + 5;
        }

        Setting.Volume.VOLUME_BGM = volume;

        volumeTextes[0].color = Color.red;
    }

    void SetEffectVolume()
    {
        int volume = Setting.Volume.VOLUME_EFFECT;
        if (Input.GetKeyDown(Setting.Keys.KEY_LEFT))
        {
            volume = volume - 5 < 0 ? 0 : volume - 5;
        }
        else if (Input.GetKeyDown(Setting.Keys.KEY_RIGHT))
        {
            volume = volume + 5 > 100? 100 : volume + 5;
        }

        Setting.Volume.VOLUME_EFFECT = volume;

        volumeTextes[1].color = Color.red;
    }

}
