using UnityEngine;

/// This is the root class for all Crop type inventory items
public abstract class Crop : InventoryItem {
    public bool isDried;
    public Crop driedCrop;
}