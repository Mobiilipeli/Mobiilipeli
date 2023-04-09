using UnityEngine;
using TMPro;

public class BestTimeText : MonoBehaviour
{
    public string timeKey; // Tallennusavain parhaalle ajalle

    private void Start()
    {
        // Haetaan tallennettu aika ja asetetaan tekstikentän arvoksi
        float bestTime = PlayerPrefs.GetFloat(timeKey, Mathf.Infinity); // Jos aikaa ei ole tallennettu, käytetään Mathf.Infinity -arvoa
        GetComponent<TextMeshProUGUI>().text = "Best Time: " + bestTime.ToString("0.00") + "s";
    }
}
