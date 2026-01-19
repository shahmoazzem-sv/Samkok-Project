using UnityEngine;

[CreateAssetMenu(fileName = "Hero Card", menuName = "Hero/ Hero Card")]
public class HeroCardSO : ScriptableObject
{
    public Sprite heroSprite;
    public HeroSO hero;
    public int cardStars;
    public GameObject cardPrefab;

}
