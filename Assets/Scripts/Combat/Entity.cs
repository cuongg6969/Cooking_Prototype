using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected int maxHp;
    [SerializeField] protected int currentHp;

    public bool IsDead => currentHp <= 0;
    public int CurrentHp => currentHp;
    public int MaxHp => maxHp;

    protected virtual void Awake()
    {
        currentHp = maxHp;
    }

    public virtual void TakeDamage(int amount, ElementType source = ElementType.None)
    {
        if (IsDead) return;

        int finalDamage = CaculateDamage(amount, source);
        currentHp = Mathf.Max(0, currentHp - finalDamage);

        OnDamageTaken(finalDamage);

        if (IsDead) Die();
    }

    public void Heal(int amount)
    {
        if (!IsDead) return;
        currentHp = Mathf.Min(maxHp, currentHp + amount);
    }   

    protected virtual int CaculateDamage(int amount, ElementType source) => amount;
    protected virtual void OnDamageTaken(int amount) { }
    protected virtual void OnHeal(int amount) { }
    protected virtual void Die() { }
}
