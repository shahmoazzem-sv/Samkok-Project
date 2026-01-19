using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class HeroCardsInHand : MonoBehaviour
{

    [SerializeField] GameObject heroCardPrefab;



    public void LoadAllCardsInHand(List<HeroCardSO> allHeroCards)
    {
        foreach (var card in allHeroCards)
        {
            GameObject cardGo = Instantiate(heroCardPrefab, transform);
            HeroCard newCard = cardGo.GetComponent<HeroCard>();
            newCard.Setup(card);
        }
    }
}
