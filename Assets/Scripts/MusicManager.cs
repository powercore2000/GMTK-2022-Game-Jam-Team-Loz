using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    static MusicManager instance;
    static float MusicVol = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            StartMusicLoop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetMusicParam("Danger", 50 * (float)Math.Sin(2 * Math.PI * Time.timeSinceLevelLoad / 120 - 0.5) + 50);

        if (SceneManager.GetActiveScene().buildIndex == 2) {
            MuteMusicLoop();
        }
        else 
        {
            UnmuteMusicLoop();
        }

    }

    public void SetMusicParam(string paramName, float newValue)
    {
        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter(paramName, newValue);

        if (paramName == "MusicVol")
        {
            MusicVol = newValue;
        }

    }

    public void StartMusicLoop()
    {
        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.Play();
    }

    public void MuteMusicLoop()
    {
        SetMusicParam("LoopActive", 0);
    }

    public void UnmuteMusicLoop()
    {
        SetMusicParam("LoopActive", 1);
    }

    public static float GetMusicVol(){
        return MusicVol;
    }

}
