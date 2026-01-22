using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class PlayerCards : MonoBehaviour
{
    [SerializeField] HeroCardDBSO motherDB;
    [SerializeField] HeroCardsCollection heroCardsCollection;

    void Start()
    {
        DBContext.Instance.SaveData(new HeroCardRecord() { cardId = 1, count = 1, level = 1 }); // this has to accomodate the functionality of saving the card so that if there is a card existing in the database then the card count will be going up only if the level is same
        List<HeroCardRecord> db = DBContext.Instance.LoadData<HeroCardRecord>();
        List<HeroCardSO> inCollection = new List<HeroCardSO>();
        if (heroCardsCollection != null)
        {
            foreach (HeroCardRecord snapshot in db)
            {
                for (int i = 0; i < snapshot.count; ++i)
                {
                    var FoundCard = motherDB.GetHeroCardSO(snapshot.cardId);
                    if (FoundCard)
                        inCollection.Add(FoundCard);
                }
            }
        }
        heroCardsCollection.LoadAllCardsInCollectionFromDatabase(inCollection);
    }
}
