using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenuControl : MonoBehaviour
{
    private GameObject pauseMen;
    private void Start()
    {
        pauseMen = this.gameObject;
    }
    public void ResumeGame()
    {
        pauseMen.SetActive(false);
    }

    public void SaveExit()
    {
        //call save method
        //load main menu scene
    }
}
