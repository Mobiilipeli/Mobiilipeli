using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Prefab, josta putket kloonataan
    public GameObject prefab;

    // Aika, jonka v‰lein putket kloonataan
    public float spawnRate = 1f;

    // Alin korkeus, johon putket voivat spawnata
    public float minHeight = -1f;

    // Ylin korkeus, johon putket voivat spawnata
    public float maxHeight = 2f;

    private void OnEnable()
    {
        // Kutsutaan Spawn()-metodia toistuvasti
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        // Peruuttaa Spawn()-metodin toistuvat kutsut
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // Kloonaa prefab, joka sis‰lt‰‰ sek‰ yl‰- ett‰ alaputken
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        // Asettaa putkien korkeuden satunnaisesti v‰lille minHeight ja maxHeight
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

}
