using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnviromentSystems.SceneLoading;

public class MainMenuControl : MonoBehaviour
{

    [SerializeField]
    SceneManagerBehaviour sceneMgrBhv;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject creditsCanvas;

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
        //Hide everything in the menu canvas and show a different canvas
        //DOES THIS VIA GAMEOBJECT.ACTIVE - MIGHT HAVE ISSUES ON CONTROLLERS MAYBE, I'M NOT SURE
        //HOPEFULLY NOT, BUT IF SO, IT MIGHT BE THIS
        menuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void ShowTitle()
    {
        menuCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }
}
