using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVictory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("MusicVol", MusicManager.GetMusicVol());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
