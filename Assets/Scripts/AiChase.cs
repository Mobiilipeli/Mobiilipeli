using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChase : MonoBehaviour
{
    // Pelaajan peliobjekti, jota AI seuraa.
    public GameObject player;

    // AI:n nopeus.
    public float speed;

    // Et�isyys pelaajan ja AI:n v�lill�, jolloin AI alkaa seurata pelaajaa.
    public float distanceBetween;

    // Et�isyys pelaajan ja AI:n v�lill�.
    private float distance;

    // Start-metodi kutsutaan ennen ensimm�ist� framia.
    void Start()
    {

    }

    // Update-metodi kutsutaan kerran joka framella.
    void Update()
    {
        // Lasketaan et�isyys pelaajan ja AI:n v�lill� k�ytt�m�ll� Vector2.Distance -funktiota.
        distance = Vector2.Distance(transform.position, player.transform.position);

        // Lasketaan suunta pelaajasta AI:hin k�ytt�m�ll� Vector2-vektoria.
        Vector2 direction = player.transform.position - transform.position;

        // Jos pelaaja on riitt�v�n l�hell�, niin AI liikkuu pelaajan suuntaan k�ytt�m�ll� Vector2.MoveTowards -funktiota.
        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
