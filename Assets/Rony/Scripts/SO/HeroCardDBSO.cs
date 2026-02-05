using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero Card", menuName = "Hero/HeroCardDBSO")]
class HeroCardDBSO : ScriptableObject
{
    [SerializeField] private List<HeroCardSO> allHeroCardSO;
    public List<HeroCardSO> AllHeroCardSO => allHeroCardSO;

    public HeroCardSO GetHeroCardSO(int heroCardID)
    {
        return allHeroCardSO.Find((e) => e.heroCardID == heroCardID);
    }
}