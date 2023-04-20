using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Metodi, joka tarkistaa, onko käyttäjä painanut mitään näppäintä.
    // Jos käyttäjä painaa näppäintä, siirrytään päävalikkoon.
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Menu();
        }
    }
}
