using UnityEngine;

public class ObjectMotion : MonoBehaviour
{
    [Header("Movement")]
    public bool enableMovement = true;
    public Vector3 movementAxis = Vector3.right; // X, Y, or Z direction
    public float moveDistance = 3f;
    public float moveSpeed = 2f;

    [Header("Rotation")]
    public bool enableRotation = false;
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 50f;

    [Header("Options")]
    public bool useLocalSpace = false;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // LOOPING MOVEMENT (Ping-Pong)
        if (enableMovement)
        {
            float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
            Vector3 direction = movementAxis.normalized * offset;

            if (useLocalSpace)
                transform.localPosition = startPosition + direction;
            else
                transform.position = startPosition + direction;
        }

        // ROTATION
        if (enableRotation)
        {
            Vector3 rotation = rotationAxis.normalized * rotationSpeed * Time.deltaTime;

            if (useLocalSpace)
                transform.Rotate(rotation, Space.Self);
            else
                transform.Rotate(rotation, Space.World);
        }
    }
}