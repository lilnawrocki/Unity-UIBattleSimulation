using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class Selectable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    private Button button;

    private Color defaultColor, pressedColor;
    void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        if (image) defaultColor = image.color;
        if (button) pressedColor = button.colors.pressedColor;
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
