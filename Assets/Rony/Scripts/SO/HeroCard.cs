
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroCard : MonoBehaviour
{

    [SerializeField] TMP_Text Name;
    [SerializeField] TMP_Text Level;

    [SerializeField] Image cardImage;


    public void Setup(HeroCardSO cardSO)
    {
        cardImage.sprite = cardSO.heroSprite;
        Name.text = cardSO.name;
        Level.text = cardSO.level.ToString();
    }
}
