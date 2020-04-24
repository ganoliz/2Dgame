using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCurrentOptionData : MonoBehaviour
{
    public enum Type{
        volume,
        effect,

    }
    public Type type;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case Type.volume:
                slider.value = OptionData.VOLUME;
                break;
            case Type.effect:
                slider.value = OptionData.EFFECTVOLUME;
                break;



            default:
                break;
        }
    }
}
