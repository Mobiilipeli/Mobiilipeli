using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;

    public GameObject player;

    public ParticleSystem particle;


    // Kun peli p��ttyy, asetetaan game over -valikko n�kyv�ksi ja soitetaan ��niefekti
    public void gameOver()
    {
        gameOverUI.SetActive(true);
        playGameOverSound();

        // Etsi p��kamera scenest�
        Camera mainCamera = Camera.main;

        // Generoi satunnainen paikka tietyll� et�isyydell�
        Vector3 shakePos = Random.insideUnitSphere * 2f;

        // Ravista kameraa lis��m�ll� t�rin� paikka sen nykyiseen sijaintiin
        // mainCamera.transform.position += shakePos;

        // asettaa pelaajan epäaktiiviseksi
        player.SetActive(false);

        // siirtää particle systemin pelaajan positioon
        particle.transform.position = player.transform.position;

        // kuolema-animaatio
        particle.Play();
    }

    // Kun pelaaja aloittaa pelin uudelleen, ladataan nykyinen scene uudelleen ja pys�ytet��n ��niefekti
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GetComponent<AudioSource>().Stop();
    }

    // Soitetaan game over -��nieffekti
    public void playGameOverSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
