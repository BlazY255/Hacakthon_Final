using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickVisualizer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image buttonImage;
    public Sprite downSprite;
    public Sprite upSprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == this.gameObject)
        {
            buttonImage.sprite = downSprite;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == this.gameObject)
        {
            buttonImage.sprite = upSprite;
        }
    }
}