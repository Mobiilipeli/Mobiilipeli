using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Peliobjekti, jota kamera seuraa.
    public Transform target;

    // Vektori, joka m‰‰ritt‰‰ kameran et‰isyyden kohteesta.
    public Vector3 offset;

    // Kerroin, joka m‰‰ritt‰‰ kuinka nopeasti kamera seuraa kohdetta.
    [Range(1, 10)]
    public float smoothFactor;

    // Vektori, joka m‰‰ritt‰‰ kameran liikkumisen alueen minimiarvot.
    public Vector3 minValues;

    // Vektori, joka m‰‰ritt‰‰ kameran liikkumisen alueen maksimiarvot.
    public Vector3 maxValues;

    // FixedUpdate-metodi kutsutaan tietyn ajan kuluttua.
    private void FixedUpdate()
    {
        Follow();
    }

    // Follow-metodi liikuttaa kameraa kohti kohdeobjektia.
    void Follow()
    {
        // M‰‰rit‰ minimi- ja maksimiarvot x-, y- ja z-koordinaateille.

        // M‰‰rit‰ uusi sijainti kohdeobjektin ja offsetin avulla.
        Vector3 targetPosition = target.position + offset;

        // Rajoita kameran liikkumista minimi- ja maksimiarvojen sis‰ll‰.
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z));

        // Siirry kohti rajoitettua sijaintia Lerp-funktion avulla.
        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
