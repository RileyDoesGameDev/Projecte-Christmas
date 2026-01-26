using UnityEngine;
using UnityEngine.InputSystem;

public class RoomTriggers : MonoBehaviour
{
    public GameObject linkedDoorTrigger;
    public Vector3 positionOffset = new Vector3(0, 0.1f, 0);
    public bool Unlocked = true; // Set to false if you want it locked by default

    private bool playerInTrigger = false;
    private CharacterController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;
            playerController = other.GetComponent<CharacterController>();
            Debug.Log("Press E to enter door");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && playerInTrigger)
        {
            // Check if E key was pressed this frame
            if (Keyboard.current.eKey.wasPressedThisFrame)
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
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = false;
            playerController = null;
            Debug.Log("Moved away from door");
        }
    }

    private void TeleportPlayer()
    {
        if (playerController != null)
        {
            Debug.Log("Teleporting player!");
            playerController.enabled = false;
            playerController.transform.position = linkedDoorTrigger.transform.position + positionOffset;
            playerController.enabled = true;
        }
    }
}