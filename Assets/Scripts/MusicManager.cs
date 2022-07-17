using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SetMusicParam("Danger", 50 * (float)Math.Sin( 2 * Math.PI * Time.timeSinceLevelLoad / 120) + 50);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetMusicParam(string paramName, float newValue)
    {
        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter(paramName, newValue);
    }
}
