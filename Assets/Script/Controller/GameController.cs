using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour
{
    [SerializeField] GameObject Tips;
    [SerializeField] GameObject SwapObj;
    [SerializeField] Text SwapMode;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] private AudioClip sw;
    [SerializeField] private AudioClip se;

    AudioSource audioSource;

    private Image[] swapImage;
    private Image tipsImage;

    private static bool isPause = false;

    private void Awake()
    {
        PublicObj.Template.LoadAllSprites();
        PublicObj.Template.LoadAllGameObjects();
    }

    void Start()
    {
        isPause = false;
        HideTips();
        
        swapImage = SwapObj.GetComponentsInChildren<Image>();
        tipsImage = Tips.GetComponentInChildren<Image>();

        Stage.Stage1 stage = new Stage.Stage1();
        Stage.Stage stage1 = stage.GetStage();
        Stage.StageUtils.CreateStage(stage1);

        Setting.Game.CURRENTROOM = stage1.Rooms[0].RoomName;
        PauseMenu.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }

        if (isPause)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }

    public void Resume()
    {
        isPause = false;
    }

    public void ShowTips(Vector3 pos)
    {
        Tips.SetActive(true);
        string KeyCodeName = "KB_" + Setting.Keys.KEY_ABILITY.ToString();
        tipsImage.sprite = PublicObj.Template.GetSprite(KeyCodeName);
        Tips.transform.position = pos;
    }

    public void HideTips()
    {
        Tips.SetActive(false);
    }

    public void SetObj(string name)
    {
        swapImage[2].sprite = PublicObj.Template.GetSprite(name);
    }

    public void DeleteObj()
    {
        swapImage[2].sprite = PublicObj.Template.GetSprite("forbidden");
    }

    public void SetMode(string mode)
    {
        SwapMode.text = mode;
    }

    public void PlaySw()
    {
        audioSource.PlayOneShot(sw, Setting.Volume.VOLUME_EFFECT / 100f);
    }

    public void PlaySe()
    {
        audioSource.PlayOneShot(se, Setting.Volume.VOLUME_EFFECT / 100f);
    }
}
