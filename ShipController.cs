using UnityEngine;

public class ShipController : MonoBehaviour
{
    private ShipPawn pawn;

    // For arrow key single-press detection
    private bool arrowUpHeld, arrowDownHeld, arrowLeftHeld, arrowRightHeld;

    void Start()
    {
        pawn = GetComponent<ShipPawn>();
    }

    void Update()
    {
        HandleMovement();
        HandleTeleports();
    }

    private void HandleMovement()
    {
        // Turbo mode
        float currentSpeed = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                            ? pawn.turboSpeed
                            : pawn.moveSpeed;
        
        // Forward/backward
        if (Input.GetKey(KeyCode.W))
            pawn.MoveForward(currentSpeed);
        if (Input.GetKey(KeyCode.S))
            pawn.MoveForward(-currentSpeed);
        
        // Rotation
        if (Input.GetKey(KeyCode.A))
            pawn.Rotate(pawn.rotateSpeed);
        if (Input.GetKey(KeyCode.D))
            pawn.Rotate(-pawn.rotateSpeed);
    }

    private void HandleTeleports()
    {
        // Random teleport with T
        if (Input.GetKeyDown(KeyCode.T))
            pawn.RandomTeleport();
        
        // Arrow key teleports
        if (Input.GetKeyDown(KeyCode.UpArrow) && !arrowUpHeld)
        {
            pawn.ArrowTeleport(Vector3.up);
            arrowUpHeld = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) arrowUpHeld = false;

        if (Input.GetKeyDown(KeyCode.DownArrow) && !arrowDownHeld)
        {
            pawn.ArrowTeleport(Vector3.down);
            arrowDownHeld= true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) arrowDownHeld = false;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !arrowLeftHeld)
        {
            pawn.ArrowTeleport(Vector3.left);
            arrowLeftHeld = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) arrowLeftHeld = false;

        if (Input.GetKeyDown(KeyCode.RightArrow) && !arrowRightHeld)
        {
            pawn.ArrowTeleport(Vector3.right);
            arrowRightHeld = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) arrowRightHeld = false;
    }
}
