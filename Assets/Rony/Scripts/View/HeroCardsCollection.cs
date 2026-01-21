using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class HeroCardsCollection : MonoBehaviour // TODO: Implement Chest Box Rule
{

    [SerializeField] GameObject heroCardPrefab;



    public void LoadAllCardsInCollectionFromDatabase(List<HeroCardSO> allHeroCards)
    {
        foreach (var card in allHeroCards)
        {
            Debug.Log(card.cardStars);
            GameObject cardGo = Instantiate(heroCardPrefab, transform);
            HeroCard newCard = cardGo.GetComponent<HeroCard>();
            newCard.Setup(card);
        }
    }
}
