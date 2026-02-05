using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class HeroCardFrame : MonoBehaviour, IPointerClickHandler
{
    private HeroCardSquad heroCardSquad;
    private Image thisFrameImage;
    void Awake()
    {
        heroCardSquad = GetComponentInParent<HeroCardSquad>();
        thisFrameImage = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        heroCardSquad.currentFrame = this;
    }
    void Update()
    {
        UpdateCardFrameColor();

    }
    public void InactiveImage()
    {
        // thisFrameImage.enabled = false;
    }

    void UpdateCardFrameColor()
    {
        if (heroCardSquad.currentFrame == null) return;
        if (heroCardSquad.currentFrame.transform == transform)
        {
            thisFrameImage.color = Color.red;
        }
        else
        {
            thisFrameImage.color = Color.white;
        }
    }
}
