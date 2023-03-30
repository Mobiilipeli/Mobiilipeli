using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false; // Muuttuja, joka kertoo onko peli pys‰ytetty
    public GameObject PauseMenuCanvas; // Pelin pys‰ytysvalikon kanvas

    // Start-metodi kutsutaan ennen ensimm‰ist‰ framea
    void Start()
    {
        Time.timeScale = 1f; // Asetetaan ajan kiihtyvyys normaaliksi
    }

    // Update-metodi kutsutaan jokaisen framen yhteydess‰
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Jos Esc-n‰pp‰int‰ painetaan
        {
            if (Paused) // Jos peli on jo pys‰ytetty
            {
                Play(); // Jatketaan peli‰
            }
            else // Muussa tapauksessa
            {
                Stop(); // Pys‰ytet‰‰n peli
            }
        }
    }

    // Pys‰ytt‰‰ pelin ja avaa pelin pys‰ytysvalikon
    public void Stop()
    {
        PauseMenuCanvas.SetActive(true); // N‰ytet‰‰n pelin pys‰ytysvalikko
        Time.timeScale = 0f; // Asetetaan ajan kiihtyvyys nollaksi, jolloin peli pys‰htyy
        Paused = true; // Asetetaan muuttuja Paused totuusarvoksi true
    }

    // Jatkaa peli‰ ja piilottaa pelin pys‰ytysvalikon
    public void Play()
    {
        PauseMenuCanvas.SetActive(false); // Piilotetaan pelin pys‰ytysvalikko
        Time.timeScale = 1f; // Asetetaan ajan kiihtyvyys normaaliksi, jolloin peli jatkuu
        Paused = false; // Asetetaan muuttuja Paused totuusarvoksi false
    }

    // Palaa p‰‰valikkoon ja asettaa ajan kiihtyvyyden normaaliksi
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0); // Ladataan ensimm‰inen Scene
        Time.timeScale = 1f; // Asetetaan ajan kiihtyvyys normaaliksi, jolloin peli jatkuu
        Paused = false; // Asetetaan muuttuja Paused totuusarvoksi false
    }
}
