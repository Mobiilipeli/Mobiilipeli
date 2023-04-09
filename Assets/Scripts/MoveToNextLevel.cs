using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    private Dictionary<int, float> levelTimes; // 1. Create a dictionary to hold the completion times for all levels.
    public TextMeshProUGUI bestTimeText; // 2. Declare a UI Text object to display the best completion time.

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        levelTimes = new Dictionary<int, float>(); // 3. Initialize the dictionary.

        // 4. Load all saved completion times into the dictionary.
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            float completionTime = PlayerPrefs.GetFloat("levelTime" + i.ToString(), 0f);
            levelTimes.Add(i, completionTime);
        }

        // 5. Retrieve and display the best completion time for the current scene.
        float bestTime = levelTimes[SceneManager.GetActiveScene().buildIndex];
        if (bestTime > 0)
        {
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2") + "s";
        }
        else
        {
            bestTimeText.text = "No Best Time Set Yet";
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

                // Show victory screen or perform other end-game actions.
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
