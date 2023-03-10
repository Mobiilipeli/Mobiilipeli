using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Tämä metodi kutsutaan, kun pelaaja painaa "Play Game" -painiketta.
    public void PlayGame()
    {
        // Ladataan seuraava buildindeksi Scene Managerista.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Tämä metodi kutsutaan, kun pelaaja painaa "Quit" -painiketta.
    public void QuitGame()
    {
        // Tulostetaan "QUIT!" konsoliin (debuggausta varten).
        Debug.Log("QUIT!");

        // Lopetetaan sovelluksen suorittaminen.
        Application.Quit();
    }
}
