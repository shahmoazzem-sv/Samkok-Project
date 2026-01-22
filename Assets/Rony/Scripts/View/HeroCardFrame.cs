using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class HeroCardFrame : MonoBehaviour, IPointerClickHandler
{
    private HeroCardSquad heroCardSquad;
    private Image thisFrame;
    void Awake()
    {
        heroCardSquad = GetComponentInParent<HeroCardSquad>();
        thisFrame = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        heroCardSquad.currentCardPosition = transform.position;
    }
    void Update()
    {
        if (heroCardSquad.currentCardPosition == transform.position)
        {
            thisFrame.color = Color.red;
        }
        else
        {
            thisFrame.color = Color.white;
        }
    }
}
