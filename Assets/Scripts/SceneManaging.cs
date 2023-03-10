using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    // Metodi vaihtaa pelin nykyisen kohtauksen haluttuun kohtaukseen annetun kokonaislukuarvon perusteella.
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Metodi sulkee pelin sovelluksen.
    public void QuitGame()
    {
        Application.Quit();
    }
}

