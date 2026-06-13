using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    [SerializeField] IngredientSO testIngredient;  // kéo SO vào Inspector

    void Update()
    {
        // Nhấn A → thêm nguyên liệu
        if (Input.GetKeyDown(KeyCode.A))
        {
            EventBus.Publish(new OnIngredientHarvested { data = testIngredient });
            Debug.Log("[TEST] Harvest ingredient");
        }

        // Nhấn S → in danh sách
        if (Input.GetKeyDown(KeyCode.S))
        {
            var list = InventorySystem.Instance.GetAll();
            foreach (var item in list)
                Debug.Log($"  - {item.data.ingredientName} | {item.freshness:F1}% | {item.FreshnessLabel()}");
        }
    }
}