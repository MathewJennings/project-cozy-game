using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfIngredientSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject backgroundObject;

    [SerializeField]
    private GameObject ingredientsObject;

    [SerializeField]
    private GameObject brewingIngredientPrefab;

    [SerializeField]
    private Inventory playerInventory;

    [SerializeField]
    private int targetSizeInPixels = 256;

    private List<GameObject> shelfIngredients = new();

    public GameObject GetShelfBackground()
    {
        return backgroundObject;
    }

    public float GetTargetSpriteSize()
    {
        return targetSizeInPixels;
    }

    public void RemoveShelfIngredient(GameObject shelfIngredient)
    {
        if (shelfIngredients.Contains(shelfIngredient))
        {
            shelfIngredient.transform.parent = null;
            shelfIngredients.Remove(shelfIngredient);
        }
        PositionShelfIngredients();
    }

    public void AddShelfIngredient(GameObject shelfIngredient)
    {
        if (shelfIngredients.Contains(shelfIngredient))
        {
            shelfIngredients.Remove(shelfIngredient);
        }
        shelfIngredient.transform.parent = ingredientsObject.transform;
        Vector3 localPos = shelfIngredient.transform.localPosition;
        for (int i = 0; i < shelfIngredients.Count; i++)
        {
            if (shelfIngredients[i].transform.localPosition.x > localPos.x)
            {
                shelfIngredients.Insert(i, shelfIngredient);
                break;
            }
        }
        if (!shelfIngredients.Contains(shelfIngredient))
        {
            shelfIngredients.Add(shelfIngredient);
        }
        PositionShelfIngredients();
    }

    void Start()
    {
        for (int i = 0; i < playerInventory.Count(); i++)
        {
            InventoryItem inventoryItem = playerInventory.Get(i).GetInventoryItem();
            if (inventoryItem is Ingredient)
            {
                SpawnShelfIngredient(inventoryItem as Ingredient);
            }
        }
        PositionShelfIngredients();
        backgroundObject.transform.localScale = new Vector3(shelfIngredients.Count, 1, 1);
    }

    private void SpawnShelfIngredient(Ingredient ingredient)
    {
        GameObject shelfIngredient = Instantiate(brewingIngredientPrefab, ingredientsObject.transform);
        shelfIngredients.Add(shelfIngredient);
        BrewingIngredient brewingIngredient = shelfIngredient.GetComponent<BrewingIngredient>();
        brewingIngredient.Initialize(ingredient, this);
    }

    private void PositionShelfIngredients()
    {
        for (int i = 0; i < shelfIngredients.Count; i++)
        {
            float localX = i - shelfIngredients.Count / 2 + (shelfIngredients.Count % 2 == 0 ? 0.5f: 0f);
            shelfIngredients[i].transform.localPosition = new Vector3(localX, 0, 0);
        }
    }
}
