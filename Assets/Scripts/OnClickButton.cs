﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnClickButton : MonoBehaviour
{
    MenuControll menuControll;
    GameControll gameControll;
    // Start is called before the first frame update
    void Start()
    {
        menuControll = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuControll>();
        gameControll = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControll>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        // MazeData.LOAD = false;
        //  menuControll.SetMenuActive("SelectDifficultyMenu");

        SceneManager.LoadScene("MainScene");
    }

    public void Load()
    {
        // 未製作
        menuControll.SetMenuActive("LoadMenu");
    }

    public void Option()
    {
        menuControll.SetMenuActive("OptionMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        menuControll.SetMenuActive("MainMenu");
    }



  /*  public void Custom()
    {
        menuControll.SetMenuActive("CustomMenu");
    }

    public void CustomPlay()
    {
        GameObject[] sliders = GameObject.FindGameObjectsWithTag("slider");
        MazeData.MAZE_X = (int)sliders[0].GetComponent<Slider>().value;
        MazeData.MAZE_Y = (int)sliders[1].GetComponent<Slider>().value;
        SceneManager.LoadScene("MainScene");
    }
    */   
    public void ClickReset()
    {
        OptionData.VOLUME = 0.8f;
        OptionData.EFFECTVOLUME = 0.8f;

    }

    public void Resume()
    {
        gameControll.Resume();
    }
    public void Restart()
    {
        gameControll.Restart();
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GameOption()
    {
        gameControll.showOptionMenu();
    }
    public void BackToPauseMenu()
    {
        gameControll.hideOptionMenu();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Save()
    {
        gameControll.ShowInputBox();
    }
    public void FileCancel()
    {
        gameControll.HideInputBox();
    }
    public void FileConfirm()
    {
        TMPro.TextMeshProUGUI inputField = GameObject.FindGameObjectWithTag("inputField").GetComponentsInChildren<TMPro.TextMeshProUGUI>()[1];
        string filename = inputField.text;
        filename = filename.Substring(0, filename.Length - 1);          // 扣掉空字元

        if(filename == "")
        {
            Debug.LogError("名稱不能為空");
            return;
        }
        gameControll.HideInputBox();                   // gameControll.saveMazeData(filename);      no implement so hide inputbox at here
    }
}