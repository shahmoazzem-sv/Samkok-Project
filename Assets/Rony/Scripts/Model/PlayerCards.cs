using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerCards : MonoBehaviour
{
    [SerializeField] HeroCardDBSO motherDB;
    [SerializeField] HeroCardsInHand heroCardsInHand;

    void Start()
    {
        List<HeroCardSnapshot> db = DBContext.Instance.LoadData();
        List<HeroCardSO> inCollection = new List<HeroCardSO>();
        if (heroCardsInHand != null)
        {
            foreach (HeroCardSnapshot snapshot in db)
            {
                inCollection.Add(motherDB.GetHeroCardSO(snapshot.cardId));
            }
        }
        heroCardsInHand.LoadAllCardsInHand(inCollection);
    }
}
