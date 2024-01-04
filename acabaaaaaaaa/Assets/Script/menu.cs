using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. SceneManagement;

public class menu : MonoBehaviour
{
    public void LoadScenes( string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void Quit()
    {
        Application.Quit();
    }

    
}
