﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnValueChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Voloume()
    {
        GameObject slider = GameObject.Find("Slider_Volume");
        OptionData.VOLUME = slider.GetComponent<Slider>().value;
    }
    public void VolumeEffect()
    {
        GameObject slider = GameObject.Find("Slider_SoundEffect");
        OptionData.EFFECTVOLUME = slider.GetComponent<Slider>().value;
    }
   



}
