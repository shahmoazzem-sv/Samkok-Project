using System.Collections.Generic;
using UnityEngine;

public class HeroCardsInHand : MonoBehaviour
{

    [SerializeField] GameObject heroCardPrefab;



    public void LoadAllCardsInHand(List<HeroCardSO> allCards)
    {
        foreach (var card in allCards)
        {
            GameObject cardGo = Instantiate(heroCardPrefab, transform);
            HeroCard newCard = cardGo.GetComponent<HeroCard>();
            newCard.Setup(card);

        }
    }
}
