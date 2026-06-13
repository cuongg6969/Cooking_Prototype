using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill_", menuName = "Isekai/Skill")]
public class SkillSO : ScriptableObject
{
    [Header("Info")]
    public string skillName;
    public Sprite icon;
    public string description;

    [Header("Stats")]
    public int damage;
    public float manaCost;
    public float coolDown;

    [Header("Element")]
    public ElementType element;

    // Hiện tại chưa đụng tới.

    //[Header("Gesture")]
    //public GestureType gesture;

    //[Header("Visual")]
    //public GameObject vfxPrefab;
}
