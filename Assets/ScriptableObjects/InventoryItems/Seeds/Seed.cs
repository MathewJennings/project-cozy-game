using UnityEngine;

/// This is the root class for all Seed type inventory items
public abstract class Seed : InventoryItem {
    public int daysAsSeed;
    public int daysAsSmallSapling;
    public int daysAsBigSapling;
    public int daysAsPlant;
}