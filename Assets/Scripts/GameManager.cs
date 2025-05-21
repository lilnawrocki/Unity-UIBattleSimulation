using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public GameObject CurrentSelected = null;
    void Awake()
    {
        GM = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GetSelectedButton()
    {
        CurrentSelected = EventSystem.current.currentSelectedGameObject;
    }
}
