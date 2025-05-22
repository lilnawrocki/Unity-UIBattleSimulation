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

    void Start()
    {
        Player swordsman = new Player(50, CharacterType.SWORDSMAN);
        Player mage = new Player(50, CharacterType.MAGE);
        Player backendEngineer = new Player(50, CharacterType.BACKEND_ENGINEER);

        // Enemy pinkBean = new Enemy(1, CharacterType.PINK_BEAN);
        // Enemy hornyMushroom = new Enemy(1, CharacterType.HORNY_MUSHROOM);
        // Enemy slime = new Enemy(1, CharacterType.SLIME);

        Character[] characters = { swordsman, mage, backendEngineer };

        Debug.Log($"Swordsman stats: HP: {characters[0].GetMaxHP()} MP: {characters[0].GetMaxMP()}");
        Debug.Log($"Mage stats: HP: {characters[1].GetMaxHP()} MP: {characters[1].GetMaxMP()}");
        Debug.Log($"Backend stats: HP: {characters[2].GetMaxHP()} MP: {characters[2].GetMaxMP()}");
    }
    public void GetSelectedButton()
    {
        CurrentSelected = EventSystem.current.currentSelectedGameObject;
    }
}
