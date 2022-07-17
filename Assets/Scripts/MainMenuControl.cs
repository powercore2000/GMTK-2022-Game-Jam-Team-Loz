using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControl : MonoBehaviour
{
    public void StartNewGame()
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
