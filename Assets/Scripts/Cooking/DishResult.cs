using UnityEngine;
using UnityEngine.UIElements.Experimental;

[System.Serializable]
public class DishResult 
{
    public RecipeSO recipe;
    public int quality;
    public float FreshnessAvg;
    public float gestureAccuracy;
    public ElementType elementBonus;
    public int finalPrice;

    public string QualityLabel()
    {
        return quality switch
        {
            5 => "Mĩ vị nhân gian",
            4 => "Xuất sắc",
            3 => "ngon",
            2 => "Bình thường",
            _ => "Dở"
        };
    }
}
