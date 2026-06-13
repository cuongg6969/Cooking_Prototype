using UnityEngine;

[CreateAssetMenu(fileName = "Ally_", menuName = "Isekai/Ally")]
public class AllySO : ScriptableObject
{
    [Header("Info")]
    public string allyName;
    public Sprite sprite;

    [Header("Stats")]
    public int max;
    public int PhysicalAttack;
    public int magicAttack;
    public int defend;
    public int moveRange;
    public int attackRange;

    [Header("Element")]
    public ElementType element;

    [Header("Skill")]
    public SkillSO[] skills;
}
