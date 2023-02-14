using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class GameManager : MonoBehaviour
{
    // Viittaus pelaajaan
    public Player player;
    // Viittaus Spawner-luokkaan
    private Spawner spawner;

    // Viittaus tekstikenttään, jossa näytetään pelaajan pisteet
    public Text scoreText;

    // GameObject-nimet, jotka on tarkoitus aktivoida/poistaa käytöstä pelin aikana
    public GameObject playButton;
    public GameObject gameOver;

    // Pelaajan pisteet
    public int score { get; private set; }

    private void Awake()
    {
        // Rajoita pelin frameratea 60 fps:iin
        Application.targetFrameRate = 60;

        // Hae viittaukset pelaajaan ja Spawner-luokkaan
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        // Pysäytä peli alussa
        Pause();
    }

    // Käynnistä peli
    public void Play()
    {
        // Alusta pelaajan pisteet ja päivitä tekstikenttä
        score = 0;
        scoreText.text = score.ToString();

        // Piilota pelinappula ja pelin loppunäkymä
        playButton.SetActive(false);
        gameOver.SetActive(false);

        // Aloita peli ja aktivoi pelaajan kontrollit
        Time.timeScale = 1f;
        player.enabled = true;

        // Poista kaikki putket, jotka ovat jo kentällä
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    // Peli päättyy
    public void GameOver()
    {
        // Näytä pelinappula ja pelin loppunäkymä
        playButton.SetActive(true);
        gameOver.SetActive(true);

        // Pysäytä peli
        Pause();
    }

    // Pysäytä peli
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    // Kasvata pelaajan pisteitä yhdellä ja päivitä tekstikenttä
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
