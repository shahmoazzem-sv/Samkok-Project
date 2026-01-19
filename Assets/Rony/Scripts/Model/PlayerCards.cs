using System.Collections.Generic;
using UnityEngine;

public class PlayerCards : MonoBehaviour
{
    [SerializeField] List<HeroCardSO> playerHeroCards;
    [SerializeField] HeroCardsInHand heroCardsInHand;
    public List<HeroCardSO> PlayerHeroCards => playerHeroCards;

    void Start()
    {
        if (heroCardsInHand != null)
        {
            heroCardsInHand.LoadAllCardsInHand(playerHeroCards);
        }
    }






}
