public interface IIngredientAddRemoveObserver
{
    public void IngredientAdded(BrewingIngredient brewingIngredient);

    public void IngredientRemoved(BrewingIngredient brewingIngredient);
}
