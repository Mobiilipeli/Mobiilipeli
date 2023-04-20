using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    private Dictionary<int, float> levelTimes; // Luo sanakirja, johon tallennetaan kaikkien tasojen suoritusaikojen tiedot.
    public TextMeshProUGUI bestTimeText; // Määritä käyttöliittymän tekstialue, johon näytetään paras suoritusaika.

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        levelTimes = new Dictionary<int, float>(); // Alusta sanakirja.

        // Lataa tallennetut suoritukset sanakirjaan.
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            float completionTime = PlayerPrefs.GetFloat("levelTime" + i.ToString(), 0f);
            levelTimes.Add(i, completionTime);
        }

        // Etsi ja näytä parhaat suoritusajat nykyiselle tasolle.
        float bestTime = levelTimes[SceneManager.GetActiveScene().buildIndex];
        if (bestTime > 0)
        {
            bestTimeText.text = "Best Time: " + bestTime.ToString("F1");
        }
        else
        {
            bestTimeText.text = " ";
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            float currentTime = Time.timeSinceLevelLoad;
            float bestTime = levelTimes[currentSceneIndex];
            if (bestTime == 0 || currentTime < bestTime)
            {
                levelTimes[currentSceneIndex] = currentTime;
                PlayerPrefs.SetFloat("levelTime" + currentSceneIndex.ToString(), currentTime);
                Debug.Log("Level " + currentSceneIndex.ToString() + " new best time: " + currentTime.ToString());
            }
            else
            {
                Debug.Log("Level " + currentSceneIndex.ToString() + " time: " + currentTime.ToString() + " not better than previous best time: " + bestTime.ToString());
            }

            if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                Debug.Log("You Completed ALL Levels");

                // Näytä voittoruutu tai suorita muita loppupelin toimintoja.
            }
            else
            {
                SceneManager.LoadScene(nextSceneLoad);

                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }

    private void OnDestroy()
    {
        float totalBestTime = 0f;

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            float bestTime = levelTimes[i];
            if (bestTime > 0)
            {
                totalBestTime += bestTime;
            }
            Debug.Log("Level " + i.ToString() + " time: " + bestTime.ToString());
        }

        Debug.Log("Total best time: " + totalBestTime.ToString());
    }
}
