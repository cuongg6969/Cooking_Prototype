using UnityEngine;

[CreateAssetMenu(fileName ="Recipe_", menuName = "Isekai/Recipe")]
public class RecipeSO : ScriptableObject
{
    [Header("Info")]
    public string recipeName;
    public Sprite dishIcon;
    public string Description;

    [Header("Ingredients")]
    public IngredientSO[] requireIngredients;

    [Header("Cooking Step")]
    public CookingStep[] steps;

    [Header("Result")]
    [Range(1, 5)]
    public int baseQuality;
    public ElementType elementBonus;
    public int basePrice;
}

[System.Serializable]
public class CookingStep
{
    public string nameStep;
    public GestureType requireGesture;
    public float timeWindown;
}
