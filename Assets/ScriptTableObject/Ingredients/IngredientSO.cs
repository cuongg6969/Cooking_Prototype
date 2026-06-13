using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient_", menuName = "Isekai/Ingredient")]
public class IngredientSO : ScriptableObject
{
    [Header("Info")]
    public string ingredientName;
    public Sprite icon;
    public string description;

    [Header("Freshness")]
    public float freshnessDecayPerHour = 5f;

    [Header("Element")]
    public ElementType elementAffinity;

    [Header("Economy")]
    public int basePrice;
}
