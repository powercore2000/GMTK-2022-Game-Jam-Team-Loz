using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnviromentSystems.SceneLoading;

public class MainMenuControl : MonoBehaviour
{

    [SerializeField]
    SceneManagerBehaviour sceneMgrBhv;

    public void StartNewGame(int levelIndex)
    {

        //if save data exists
        //display pop-up window "This will delete existing save data. Continue?"
        //if yes
        //clear player save data
        //scene transfer to first level
        //else
        //close dialog box
        //else
        //scene transfer to first level
        sceneMgrBhv.LoadNewLevelByIndex(levelIndex);

    }

    public void LoadGame(int levelIndex)
    {
        sceneMgrBhv.LoadNewLevelByIndex(levelIndex);
    }

    public void ShowCredits()
    {
        //load a scene in which the game credits are shown
    }
}
