using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance { get; private set; }

    [Header("Setting")]
    [SerializeField] int maxSlots = 30;

    readonly List<IngredientInstance> _ingredients = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        TickFreshness();
    }

    public bool AddIngredient(IngredientSO data)
    {
        if (_ingredients.Count >= maxSlots)
        {
            return false;
        }

        var instance = new IngredientInstance(data);
        _ingredients.Add(instance);

        EventBus.Publish(new OnItemAdded { itemId = data.ingredientName });

        Debug.Log($"[Inventory] them: {data.ingredientName} (Tuoi: {instance.freshness}%");
        return true;
    }

    public bool RemoveIngredient(IngredientSO data)
    {
        var item = _ingredients.FirstOrDefault( i => i.data == data && !i.IsRotted);
        if (item == null)
        {
            Debug.Log($"[Inventory] Không tìm thấy: {data.ingredientName}");
            return false;
        }

        _ingredients.Remove(item);
        EventBus.Publish(new OnItemAdded { itemId = data.ingredientName });
        return true;
    }
    
    public bool HasIngredient(IngredientSO data, bool fressOnly = true)
    {
        return fressOnly ? _ingredients.Any(i => i.data == data && !i.IsRotted)
            : _ingredients.Any(i => i.data == data);
    }

    public List<IngredientInstance> GetAll() => new(_ingredients);

    void TickFreshness()
    {
        float decayThisFrame = Time.deltaTime / 60f;
        
        foreach(var item in _ingredients) {
            if (item.IsRotted) continue;

            item.freshness -= item.data.freshnessDecayPerHour * decayThisFrame;
            item.freshness = Mathf.Max(0f, item.freshness);
        }
    }

    private void OnEnable()
    {
        EventBus.Subscribe<OnIngredientHarvested>(OnHarvested);
        EventBus.Subscribe<OnEnemyKilled>(OnEnemyKilled);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<OnIngredientHarvested>(OnHarvested);
        EventBus.Unsubscribe<OnEnemyKilled>(OnEnemyKilled);
    }

    void OnHarvested(OnIngredientHarvested e)
    {
        AddIngredient(e.data);
    }

    void OnEnemyKilled(OnEnemyKilled e)
    {
        // LootSystem sẽ handle phần này
        // Tạm thời để trống
    }
}
