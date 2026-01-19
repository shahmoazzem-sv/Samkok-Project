
using UnityEngine;
using UnityEngine.UI;

public class HeroCard : MonoBehaviour
{

    [SerializeField] Image cardImage;

    public void Setup(HeroCardSO cardSO)
    {
        cardImage.sprite = cardSO.heroSprite;
    }
}
