using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_", menuName = "Isekai/Enemy")]
public class EnemySo : ScriptableObject
{
    [Header("Info")]
    public string enemyName;
    public Sprite sprite;

    [Header("Stats")]
    public int hp;
    public int damage;
    public float moveSpeed;
    public float attackRange;
    public float attackCooldown;

    [Header("Loot")]
    public IngredientSO[] possibleDrops;
    [Range(0f, 1f)]
    public float dropChange = .8f;
}
