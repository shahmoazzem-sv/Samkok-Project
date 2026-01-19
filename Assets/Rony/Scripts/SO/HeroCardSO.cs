using UnityEngine;

[CreateAssetMenu(fileName = "Hero Card", menuName = "Hero/ Hero Card")]
public class HeroCardSO : ScriptableObject
{
    public int heroCardID;
    public Sprite heroSprite;
    public GameObject heroPrefab;
    public GameObject cardPrefab;
    public int cardStars;
    public string heroName;
    public int level;
    public int maxHp;
    public int superAttackRange;
    public float speed;

}
