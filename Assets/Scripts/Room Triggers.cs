using UnityEngine;
using UnityEngine.InputSystem;

public class RoomTriggers : MonoBehaviour
{
    public GameObject linkedDoorTrigger;
    public Vector3 positionOffset = new Vector3(0, 0.1f, 0);
    public bool Unlocked = true;
    public string KeyItem;

    private bool playerInTrigger = false;
    private CharacterController playerController;

    private static RoomTriggers currentActiveDoor; // Track which door is active

    private void Update()
    {
        // Only allow teleport if THIS door is the active one
        if (playerInTrigger && currentActiveDoor == this && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (Unlocked)
            {
                TeleportPlayer();
            }
            else
            {
                Debug.Log("Door is locked");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;
            currentActiveDoor = this; // Set this as the active door
            playerController = other.GetComponent<CharacterController>();
            Debug.Log($"Press E to enter door: {gameObject.name}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = false;

            // Only clear active door if it's THIS door
            if (currentActiveDoor == this)
            {
                currentActiveDoor = null;
            }

            playerController = null;
            Debug.Log("Moved away from door");
        }
    }

    private void TeleportPlayer()
    {
        if (playerController != null)
        {
            Debug.Log($"Teleporting player from {gameObject.name} to {linkedDoorTrigger.name}!");
            playerController.enabled = false;
            playerController.transform.position = linkedDoorTrigger.transform.position + positionOffset;
            playerController.enabled = true;

            // Clear the active door after teleporting
            currentActiveDoor = null;
            playerInTrigger = false;
        }
    }
}