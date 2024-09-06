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
    private GameObject shelfIngredientPrefab;

    [SerializeField]
    private Inventory playerInventory;

    [SerializeField]
    private int targetSizeInPixels = 256;

    private List<GameObject> shelfIngredients = new();

    void Start()
    {
        for (int i = 0; i < playerInventory.Count(); i++)
        {
            InventoryItem inventoryItem = playerInventory.Get(i).GetInventoryItem();
            if (inventoryItem is Ingredient)
            {
                SpawnShelfIngredient(inventoryItem);
            }
        }
        PositionShelfIngredients();
    }

    private void SpawnShelfIngredient(InventoryItem inventoryItem)
    {
        GameObject shelfIngredient = Instantiate(shelfIngredientPrefab, ingredientsObject.transform);
        shelfIngredients.Add(shelfIngredient);
        SetIngredientSprite(shelfIngredient, inventoryItem.uiSprite);
    }

    private void SetIngredientSprite(GameObject shelfIngredient, Sprite sprite)
    {
        SpriteRenderer ingredientSpriteRenderer = shelfIngredient.GetComponent<SpriteRenderer>();
        ingredientSpriteRenderer.sprite = sprite;
        float width = ingredientSpriteRenderer.sprite.rect.width;
        float targetScale = targetSizeInPixels / width;
        shelfIngredient.transform.localScale = new Vector3(targetScale, targetScale, 1f);
    }

    private void PositionShelfIngredients()
    {
        for (int i = 0; i < shelfIngredients.Count; i++)
        {
            shelfIngredients[i].transform.localPosition = new Vector3(i - shelfIngredients.Count / 2, 0, 0);
        }
        backgroundObject.transform.localScale = new Vector3(shelfIngredients.Count, 1, 1);
    }
}
