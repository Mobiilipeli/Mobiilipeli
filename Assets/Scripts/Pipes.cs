using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Yl�putken Transform-komponentti.
    public Transform top;
    // Alaputken Transform-komponentti.
    public Transform bottom;

    // Putkien nopeus.
    public float speed = 5f;

    // N�yt�n vasemman reunan koordinaatti, johon asti putki on tarkoitus liikkua.
    private float leftEdge;

    private void Start()
    {
        // Laske n�yt�n vasemman reunan koordinaatti.
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        // Liikuta putkea vasemmalle.
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Jos putki siirtyy n�yt�n vasemman reunan ohi, tuhoa putki.
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}