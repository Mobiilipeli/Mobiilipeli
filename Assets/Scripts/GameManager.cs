using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class GameManager : MonoBehaviour
{
    // Viittaus pelaajaan
    public Player player;
    // Viittaus Spawner-luokkaan
    private Spawner spawner;

    // Viittaus tekstikentt��n, jossa n�ytet��n pelaajan pisteet
    public Text scoreText;

    // GameObject-nimet, jotka on tarkoitus aktivoida/poistaa k�yt�st� pelin aikana
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

        // Pys�yt� peli alussa
        Pause();
    }

    // K�ynnist� peli
    public void Play()
    {
        // Alusta pelaajan pisteet ja p�ivit� tekstikentt�
        score = 0;
        scoreText.text = score.ToString();

        // Piilota pelinappula ja pelin loppun�kym�
        playButton.SetActive(false);
        gameOver.SetActive(false);

        // Aloita peli ja aktivoi pelaajan kontrollit
        Time.timeScale = 1f;
        player.enabled = true;

        // Poista kaikki putket, jotka ovat jo kent�ll�
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    // Peli p��ttyy
    public void GameOver()
    {
        // N�yt� pelinappula ja pelin loppun�kym�
        playButton.SetActive(true);
        gameOver.SetActive(true);

        // Pys�yt� peli
        Pause();
    }

    // Pys�yt� peli
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    // Kasvata pelaajan pisteit� yhdell� ja p�ivit� tekstikentt�
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
