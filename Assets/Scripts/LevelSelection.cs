using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons; // Taulukko napeista, joilla pelaaja voi valita tason.

    // Start-funktio kutsutaan ennen ensimmäistä framea.
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2); /* < Muuta tämän kokonaislukuarvon
                                                             arvo vastaamaan tasonvalintakohteen
                                                             rakennusindeksiäsi Build Settings -ikkunassa. */

        // Käydään läpi kaikki tasonvalintanapit.
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            // Jos nykyinen tasonvalintanappi edustaa tasoa, joka on suurempi kuin tallennettu taso, estetään sen käyttö.
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }
}
