using UnityEngine;
using UnityEngine.EventSystems; // Required for event handling
using UnityEngine.UI; // Required for UI elements

public class HoverChangeSprite : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalSprite; // Set this in the Inspector
    public Sprite hoverSprite; // Set this in the Inspector

    private Image buttonImage; // The image component of the button

    void Start()
    {
        buttonImage = GetComponent<Image>();
        if(buttonImage != null)
        {
            buttonImage.sprite = normalSprite; // Ensure the normal sprite is set initially
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(buttonImage != null)
        {
            buttonImage.sprite = hoverSprite; // Change to hover sprite on mouse enter
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(buttonImage != null)
        {
            buttonImage.sprite = normalSprite; // Revert to normal sprite on mouse exit
        }
    }
}