using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetMusicParam("Danger", 50 * (float)Math.Sin(2 * Math.PI * Time.timeSinceLevelLoad / 120 - 0.5) + 50);
    }


    public void SetMusicParam(string paramName, float newValue)
    {
        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter(paramName, newValue);
    }
}
