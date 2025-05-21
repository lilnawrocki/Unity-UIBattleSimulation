using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Selectable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    private Button button;

    private Color defaultColor, pressedColor;
    void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        defaultColor = image.color;
        pressedColor = button.colors.pressedColor;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = pressedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = defaultColor;
    }

    

}
