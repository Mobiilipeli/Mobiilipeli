using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Yläputken Transform-komponentti.
    public Transform top;
    // Alaputken Transform-komponentti.
    public Transform bottom;

    // Putkien nopeus.
    public float speed = 5f;

    // Näytön vasemman reunan koordinaatti, johon asti putki on tarkoitus liikkua.
    private float leftEdge;

    private void Start()
    {
        // Laske näytön vasemman reunan koordinaatti.
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        // Liikuta putkea vasemmalle.
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Jos putki siirtyy näytön vasemman reunan ohi, tuhoa putki.
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}