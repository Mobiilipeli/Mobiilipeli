using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChase : MonoBehaviour
{
    // Pelaajan peliobjekti, jota AI seuraa.
    public GameObject player;

    // AI:n nopeus.
    public float speed;

    // Etäisyys pelaajan ja AI:n välillä, jolloin AI alkaa seurata pelaajaa.
    public float distanceBetween;

    // Etäisyys pelaajan ja AI:n välillä.
    private float distance;

    // Start-metodi kutsutaan ennen ensimmäistä framia.
    void Start()
    {

    }

    // Update-metodi kutsutaan kerran joka framella.
    void Update()
    {
        // Lasketaan etäisyys pelaajan ja AI:n välillä käyttämällä Vector2.Distance -funktiota.
        distance = Vector2.Distance(transform.position, player.transform.position);

        // Lasketaan suunta pelaajasta AI:hin käyttämällä Vector2-vektoria.
        Vector2 direction = player.transform.position - transform.position;

        // Jos pelaaja on riittävän lähellä, niin AI liikkuu pelaajan suuntaan käyttämällä Vector2.MoveTowards -funktiota.
        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
