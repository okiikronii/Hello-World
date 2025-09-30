using UnityEngine;

public class ShipPawn : MonoBehaviour
{
    [Header("Movement Speeds")]
    public float moveSpeed = 6f; // Units per second
    public float rotateSpeed = 180f; //Degrees per second
    public float turboSpeed = 12f; //Turbo mode units per second

    [Header("Teleport Settings")]
    public float randomTeleportRangeX = 4f;
    public float randomTeleportRangeY = 4f;
    public float arrowTeleportDistance = 1f;

    //Public functions called by controller
    public void MoveForward(float amount) =>
        transform.Translate(Vector3.up * amount * Time.deltaTime, Space.Self);

    public void Rotate(float amount) =>
        transform.Rotate(Vector3.forward, -amount * Time.deltaTime); //negative for A/D)
    
    public void RandomTeleport()
    {
        float x = Random.Range(-randomTeleportRangeX, randomTeleportRangeX);
        float y = Random.Range(-randomTeleportRangeY, randomTeleportRangeY);
        transform.position = new Vector3(x, y, transform.position.z);
    }

    public void ArrowTeleport(Vector3 direction)
    {
        transform.position += direction * arrowTeleportDistance;
    }
}
