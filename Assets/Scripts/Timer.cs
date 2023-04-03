using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [Header("Component")]
    public TextMeshProUGUI timerText; // Paikka tekstikomponentille

    [Header("Timer Settings")]
    public float levelTime; // Tason aikaraja
    public float timerLimit = 0; // Aikaraja nollassa

    // Update funktiota kutsutaan joka framella
    void Update()
    {

        if (levelTime > timerLimit) // Jos tämän hetkinen aika on isompi kuin aikaraja objektin määrä,
                                    // kello laskee alaspäin kunnes osutaan aikarajaan ja se käynnistää tason uudelleen
        {
            levelTime = levelTime -= Time.deltaTime; // Aika laskee alaspäin
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        SetTimerText(); // Kutsutaan funktio, joka tekee ajasta stringin
    }
    private void SetTimerText() // Funktio, joka muuttaa ajan stringiksi
    {
        timerText.text = levelTime.ToString("0.0");
    }
}
