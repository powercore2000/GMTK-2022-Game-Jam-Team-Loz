using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionScreenControl : MonoBehaviour
{
    public void Quit(){
        Application.Quit();
    }
    
    public void GoToTitle(){
        SceneManager.LoadScene(0); //Load title.
    }
}
