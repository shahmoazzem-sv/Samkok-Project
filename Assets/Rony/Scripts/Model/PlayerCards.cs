using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class PlayerCards : MonoBehaviour
{
    [SerializeField] HeroCardDBSO motherDB;
    [SerializeField] HeroCardsInHand heroCardsInHand;

    void Start()
    {
        List<HeroCardSnapshot> db = DBContext.Instance.LoadData();
        Debug.Log(db.Count);
        List<HeroCardSO> inCollection = new List<HeroCardSO>();
        if (heroCardsInHand != null)
        {
            foreach (HeroCardSnapshot snapshot in db)
            {
                for (int i = 0; i < snapshot.count; ++i)
                {
                    inCollection.Add(motherDB.GetHeroCardSO(snapshot.cardId));
                }
            }
        }
        heroCardsInHand.LoadAllCardsInHand(inCollection);
    }
}
