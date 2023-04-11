using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    public TextMeshProUGUI DeathCounterText;
    private int deathCount;

    void Start()
    {
        // Find the TextMeshProUGUI component in the children of the Canvas
        DeathCounterText = GetComponentInChildren<TextMeshProUGUI>();

        // Load the death count from PlayerPrefs
        deathCount = PlayerPrefs.GetInt("DeathCount", 0);
        DeathCounterText.text = "Deaths: " + deathCount;
    }

    public void IncreaseDeaths()
    {
        deathCount++;
        DeathCounterText.text = "Deaths: " + deathCount;

        // Save the death count to PlayerPrefs
        PlayerPrefs.SetInt("DeathCount", deathCount);
    }
}