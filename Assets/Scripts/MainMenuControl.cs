using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnviromentSystems.SceneLoading;

public class MainMenuControl : MonoBehaviour
{
    public GameObject sceneMgr;
    public SceneManagerBehaviour sceneMgrBhv;

    public void Start()
    {
        sceneMgr = GameObject.Find("SceneManager");
        sceneMgrBhv = sceneMgr.GetComponent<SceneManagerBehaviour>();
    }

    public void StartNewGame()
    {
        sceneMgrBhv.LoadNewLevelByIndex(1);
        //if save data exists
        //display pop-up window "This will delete existing save data. Continue?"
        //if yes
        //clear player save data
        //scene transfer to first level
        //else
        //close dialog box
        //else
        //scene transfer to first level

    }

    public void LoadGame()
    {
        //load last level player was on
    }

    public void ShowCredits()
    {
        //load a scene in which the game credits are shown
    }
}
