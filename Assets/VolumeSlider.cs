using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private string paramName = "MusicVol";
    public MusicManager musicManager;
    private  Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void VolSliderChange(){
        //Change slider value
        musicManager.SetMusicParam(paramName, slider.value);
        Debug.Log("Vol change " + slider.value);
    }
}
