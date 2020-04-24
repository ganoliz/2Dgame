using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OptionData
{
    // static變數 選項變數
    private static float volume = 0.8f;         // 背景音樂
    private static float volume_effect = 0.8f;  // 效果音(未製作)

 

    public static float VOLUME
    {
        get { return volume; }
        set { volume = value; }
    }
    public static float EFFECTVOLUME
    {
        get { return volume_effect; }
        set { volume_effect = value; }
    }
  




}
