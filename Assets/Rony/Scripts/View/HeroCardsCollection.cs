using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class HeroCardsCollection : MonoBehaviour
{

    [SerializeField] GameObject heroCardPrefab;
    [SerializeField] HeroCardSquad heroCardSquad;
    HeroCard clickedHeroCard;
    void Start()
    {
    }
    void Update()
    {

        // if (Input.GetMouseButtonDown(0))
        // {
        //     PointerEventData pointerData = new PointerEventData(EventSystem.current);
        //     pointerData.position = Input.mousePosition;
        //     List<RaycastResult> results = new List<RaycastResult>();
        //     EventSystem.current.RaycastAll(pointerData, results);
        //     foreach (RaycastResult result in results)
        //     {
        //         // Debug.Log("Hit UI: " + result.gameObject.name);
        //         HeroCard heroCard = result.gameObject.GetComponent<HeroCard>();
        //         if (heroCard != null)
        //         {
        //             heroCard.transform.position = heroCardSquad.currentCardPosition;
        //         }
        //     }
        // }
    }

    void OnEnable()
    {
        EventBus<HeroCard>.Subscribe(HeroCardHandler);
    }
    void OnDisable()
    {
        EventBus<HeroCard>.Unsubscribe(HeroCardHandler);
    }
    void HeroCardHandler(HeroCard herocard)
    {
        if (heroCardSquad.currentFrame.transform.childCount == 0)
        {
            herocard.transform.SetParent(heroCardSquad.currentFrame.transform);
            herocard.transform.position = heroCardSquad.currentFrame.transform.position;
        }
        heroCardSquad.currentFrame.InactiveImage();
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
