using UnityEngine;

public class Parallax : MonoBehaviour
{
    // MeshRenderer, joka sis‰lt‰‰ taustan materiaalin.
    private MeshRenderer meshRenderer;

    // Animoinnin nopeus.
    public float animationSpeed = 1f;

    private void Awake()
    {
        // Hae MeshRenderer komponentti.
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // Liikuta taustan materiaalin tekstuuria animointinopeuden mukaisesti.
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
