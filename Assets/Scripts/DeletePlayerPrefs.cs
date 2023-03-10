using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    // Tämä skripti liitetään GameObjectiin, joten sen täytyy periytyä MonoBehaviour-luokasta.

    // Update-funktio kutsutaan jokaisen pelin päivityksen yhteydessä.
    void Update()
    {
        // Tarkistetaan, onko pelaaja painanut näppäintä "M".
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Jos pelaaja on painanut näppäintä "M", poistetaan kaikki tallennetut tiedot.
            PlayerPrefs.DeleteAll();
        }
    }
}

