using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemDropOff : MonoBehaviour
{
    public InventoryHolder inventoryHolder; // Reference to the InventoryHolder component attached to the player
    public float dropDistance = 2f; // Distance in front of the player where the item will be dropped

    private void Update()
    {
        // Check if the player presses the "k" key
        if (Input.GetKeyDown(KeyCode.K))
        {
            DropItem();
        }
    }

    private void DropItem()
    {
        // Find the first slot in the inventory that contains an item
        InventorySlot slotWithItem = inventoryHolder.InventorySystem.InventorySlots
            .FirstOrDefault(slot => slot.ItemData != null);

        // If a slot with an item is found and it's not empty
        if (slotWithItem != null && slotWithItem.ItemData != null)
        {
            // Get the item data for the item in the slot
            InventoryItemData itemData = slotWithItem.ItemData;

            // Remove one unit of the item from the slot
            slotWithItem.RemoveFromStack(1);

            // If the stack is now empty, clear the slot completely
            if (slotWithItem.StackSize <= 0)
            {
                slotWithItem.ClearSlot();
            }

            // Determine the position in front of the player to drop the item
            Vector3 dropPosition = transform.position + transform.forward * dropDistance;

            // Instantiate the item prefab in the world at the calculated drop position
            GameObject droppedItem = Instantiate(itemData.ItemPrefab, dropPosition, Quaternion.identity);

            // Notify any listeners (such as UI) that the inventory slot has changed
            inventoryHolder.InventorySystem.OnInventorySlotChanged?.Invoke(slotWithItem);
        }
        else
        {
            // Log a message if there are no items in the inventory to drop
            Debug.Log("No items to drop!");
        }
    }
}
