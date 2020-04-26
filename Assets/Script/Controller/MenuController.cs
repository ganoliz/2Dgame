using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject[] AllMenu;
    [SerializeField] private AudioClip sw;
    [SerializeField] private AudioClip se;

    AudioSource audioSource;
    private void Awake()
    {
        SetMenuActive("MainMenu");
        PublicObj.Template.LoadAllSprites();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void SetAllMenuInActive()
    {
        foreach (GameObject menu in AllMenu)
            menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMenuActive(string name)
    {
        int index = 0;
        foreach (GameObject menu in AllMenu)
        {
            if (menu.name == name)
            {
                break;
            }
            index++;
        }

        if (index >= AllMenu.Length)
        {
            Debug.LogError("menu" + name + "沒有找到");
            SetMenuActive("MainMenu");
        }
        else
        {
            SetAllMenuInActive();
            AllMenu[index].SetActive(true);
        }
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
