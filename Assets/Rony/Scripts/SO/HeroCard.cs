
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroCard : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] TMP_Text Name;
    [SerializeField] TMP_Text Level;

    [SerializeField] Image cardImage;
    HeroCardSO so;
    public HeroCardSO HerocardSo => so;

    public void OnPointerClick(PointerEventData eventData)
    {
        EventBus<HeroCard>.Raise(this);
    }

    public void Setup(HeroCardSO cardSO)
    {
        so = cardSO;
        cardImage.sprite = cardSO.heroSprite;
        Name.text = cardSO.name;
        Level.text = cardSO.level.ToString();
    }
}
