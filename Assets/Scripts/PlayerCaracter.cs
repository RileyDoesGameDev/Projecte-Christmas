using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    public InventoryData inventory = new InventoryData();
    private GameObject currentPickupItem = null;
    private GameObject currentInteractable = null;

    public string requiredItem = null;
    private Interactable interactable = null;
    void Update()
    {
        // Check for E key press in Update (runs every frame)
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            // Check for pickup items first
            if (currentPickupItem != null && !inventory.hasItem)
            {
                PickupItem(currentPickupItem);
            }
            // Check for interactable items (can use held items on them)
            else if (currentInteractable != null && inventory.hasItem)
            {
                interactable = currentInteractable.GetComponent<Interactable>();
               
                if(interactable.RequiredItem.ToLower() == inventory.item.name.ToLower())
                {
                    UseItem(inventory.item);

                }
            }
            else if (inventory.hasItem && currentPickupItem != null)
            {
                Debug.Log("Must drop item first");
            }
        }

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            if (inventory.hasItem)
            {
                DropItem(inventory.item);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Store reference when entering pickup range
        if (other.gameObject.CompareTag("Pickup"))
        {
            currentPickupItem = other.gameObject;
        }
        // Store reference when entering interactable range
        else if (other.gameObject.CompareTag("Interactable"))
        {
            currentInteractable = other.gameObject;

            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Clear reference when leaving pickup range
        if (other.gameObject.CompareTag("Pickup"))
        {
            currentPickupItem = null;
        }
        // Clear reference when leaving interactable range
        else if (other.gameObject.CompareTag("Interactable"))
        {
            currentInteractable = null;
        }
    }

    private void PickupItem(GameObject itemObject)
    {
        inventory.hasItem = true;
        inventory.item = itemObject;
        inventory.itemTag = itemObject.name;
        itemObject.SetActive(false);
        currentPickupItem = null; // Clear the reference after pickup
        Debug.Log($"Picked up: {itemObject.name}");
    }

    private void DropItem(GameObject itemObject)
    {
        inventory.hasItem = false;
        itemObject.SetActive(true); // Reactivate the item at its original position
        inventory.item = null;
        inventory.itemTag = null;
        Debug.Log($"Dropped: {itemObject.name}");
    }

    private void UseItem(GameObject itemObject)
    {
        inventory.hasItem = false;
        Destroy(itemObject);
        inventory.item = null;
        inventory.itemTag = null;
        Debug.Log($"Used: {itemObject.name}");
    }
}