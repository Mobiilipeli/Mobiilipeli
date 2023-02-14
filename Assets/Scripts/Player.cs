using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;     // pelaajan sprite-komponentti
    public Sprite[] sprites;                  // lista spriteista joita pelaaja k‰ytt‰‰
    private int spriteIndex;                   // indeksi jota k‰ytet‰‰n nykyiseen spriteen

    public float strength = 5f;                // hyppyvoima
    public float gravity = -9.81f;             // painovoima
    public float tilt = 5f;                    // k‰‰nnˆsnopeus

    private Vector3 direction;                 // pelaajan suunta

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   // haetaan sprite-komponentti
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);    // alustetaan animaatio
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;                            // asetetaan pelaajan aloituspaikka
        transform.position = position;
        direction = Vector3.zero;                   // alustetaan suunta
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;      // jos pelaaja painaa space-painiketta tai hiirt‰, hypp‰‰misen suunta ylˆsp‰in
        }

        // Lis‰t‰‰n painovoima ja p‰ivitet‰‰n pelaajan sijainti
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Kallistetaan lintua sen suunnan mukaan
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }

    // Animaation p‰ivitt‰minen
    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    // Kun pelaaja tˆrm‰‰ esteeseen, peli p‰‰ttyy. Kun pelaaja saavuttaa pistem‰‰r‰n kasvattavan alueen, pelaajan pisteit‰ kasvatetaan.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().GameOver();   // Jos pelaaja osuu esteeseen, peli p‰‰ttyy
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();  // Jos pelaaja saavuttaa pistem‰‰r‰n kasvattavan alueen, pelaajan pisteit‰ kasvatetaan
        }
    }

}