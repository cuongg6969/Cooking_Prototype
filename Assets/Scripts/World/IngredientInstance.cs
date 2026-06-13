using System;
using UnityEngine;

[Serializable]
public class IngredientInstance : MonoBehaviour
{
    public IngredientSO data;
    public float freshness;
    public float harvestTime;

    public IngredientInstance(IngredientSO data)
    {
        this.data = data;
        this.freshness = 100f;
        this.harvestTime = Time.deltaTime;
    }

    public bool IsFresh => freshness > 50f;
    public bool IsStale => freshness is > 0f and <= 50f;
    public bool IsRotted => freshness <= 0f;

    public string FreshnessLabel()
    {
        if (IsRotted) return "Hư";
        if (IsStale) return "Héo";
        return "Tươi";
    }


}
