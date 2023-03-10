using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad; // Seuraavan tason buildindeksi.

    // Start-funktio kutsutaan ennen ensimmäistä framea.
    void Start()
    {
        // Haetaan seuraavan tason buildindeksi Scene Managerilta.
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Tämä metodi kutsutaan, kun pelaaja osuu "triggeriin" (laatikkoon, johon on kiinnitetty "trigger"-komponentti).
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // Jos pelaaja osuu triggeriin...
        {
            if (SceneManager.GetActiveScene().buildIndex == 7) /* < Muuta tämän kokonaislukuarvon
                                                                   arvo vastaamaan viimeisen tason
                                                                   buildindeksiäsi Build Settings -ikkunassa. */
            {
                Debug.Log("You Completed ALL Levels"); // Tulostetaan konsoliin ilmoitus siitä, että kaikki tasot on läpäisty.

                // Näytetään voittoruutu tms.
            }
            else
            {
                // Siirrytään seuraavalle tasolle.
                SceneManager.LoadScene(nextSceneLoad);

                // Asetetaan tallennettu indeksi seuraavalle tasolle.
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }
}
