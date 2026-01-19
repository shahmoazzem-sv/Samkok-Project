using UnityEngine;


[CreateAssetMenu(fileName = "New Hero", menuName = "Hero/New Hero")]
public class HeroSO : ScriptableObject
{
    public string heroName;
    public int Level;
    public int MaxHp;
    public int SuperAttackRange;
    public float speed;
    public GameObject HeroPrefab;
}
