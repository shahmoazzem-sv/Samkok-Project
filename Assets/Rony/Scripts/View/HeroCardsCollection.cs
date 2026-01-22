using System.Collections.Generic;
using UnityEngine;
public class HeroCardsCollection : MonoBehaviour
{

    [SerializeField] GameObject heroCardPrefab;
    void Start()
    {
        // we need to raycast to a card and find the object and then it will be sent to the position of the other card place that is in the squad

    }

    public void LoadAllCardsInCollectionFromDatabase(List<HeroCardSO> allHeroCards)
    {
        foreach (var card in allHeroCards)
        {
            GameObject cardGo = Instantiate(heroCardPrefab, transform);
            HeroCard newCard = cardGo.GetComponent<HeroCard>();
            newCard.Setup(card);
        }
    }
}
