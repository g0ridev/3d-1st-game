using UnityEngine;

public class PlatformMaterialChange : MonoBehaviour
{
    public Material normalMaterial;
    public Material activeMaterial;

    private Renderer platformRenderer;
    private int objectsOnPlatform = 0;

    void Start()
    {
        platformRenderer = GetComponent<Renderer>();

        if (normalMaterial != null)
            platformRenderer.material = normalMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Object stepped on platform: " + collision.gameObject.name);

        objectsOnPlatform++;

        if (activeMaterial != null)
            platformRenderer.material = activeMaterial;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Object left platform: " + collision.gameObject.name);

        objectsOnPlatform--;

        if (objectsOnPlatform <= 0)
        {
            objectsOnPlatform = 0;

            if (normalMaterial != null)
                platformRenderer.material = normalMaterial;
        }
    }
}