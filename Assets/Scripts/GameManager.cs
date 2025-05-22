using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public GameObject CurrentSelected = null;
    public GameObject CharacterDetailsPanelPrefab = null;
    public Transform SelectedPartyParent = null;

    public List<Character> Characters = new List<Character>();
    public List<Button> SelectedSelectable = new List<Button>();
    void Awake()
    {
        GM = this;
    }

    void Start()
    {
        // Player swordsman = new Player(50, CharacterType.SWORDSMAN);
        // Player mage = new Player(50, CharacterType.MAGE);
        // Player backendEngineer = new Player(50, CharacterType.BACKEND_ENGINEER);

        // // Enemy pinkBean = new Enemy(1, CharacterType.PINK_BEAN);
        // // Enemy hornyMushroom = new Enemy(1, CharacterType.HORNY_MUSHROOM);
        // // Enemy slime = new Enemy(1, CharacterType.SLIME);

        // Character[] characters = { swordsman, mage, backendEngineer };

        // Debug.Log($"Swordsman stats: HP: {characters[0].GetMaxHP()} MP: {characters[0].GetMaxMP()}");
        // Debug.Log($"Mage stats: HP: {characters[1].GetMaxHP()} MP: {characters[1].GetMaxMP()}");
        // Debug.Log($"Backend stats: HP: {characters[2].GetMaxHP()} MP: {characters[2].GetMaxMP()}");
    }
    public void GetSelectedButton()
    {
        CurrentSelected = EventSystem.current.currentSelectedGameObject;
    }

    public Character CreateCharacter(CharacterType characterType)
    {
        Character character;
        if (characterType == CharacterType.SWORDSMAN ||
        characterType == CharacterType.MAGE ||
        characterType == CharacterType.BACKEND_ENGINEER)
        {
            character = new Player(1, characterType);
        }
        else
        {
            character = new Enemy(1, characterType);
        }
        AddCharacter(character);
        return character;
    }


    public void InstantiateCharacterPanel(CharacterType characterType)
    {
        GameObject characterDetailsPanelObject;
        if (CharacterDetailsPanelPrefab && SelectedPartyParent)
        {
            if (SelectedPartyParent.childCount < 3)
            {
                characterDetailsPanelObject = Instantiate(CharacterDetailsPanelPrefab, SelectedPartyParent);
                CharacterDetails characterDetails = characterDetailsPanelObject.GetComponent<CharacterDetails>();
                FillCharacterDetails(characterDetails);
            }

        }
    }

    public void FillCharacterDetails(CharacterDetails characterDetails)
    {
        Character character = Characters.ElementAt(characterDetails.GetSiblingIndex());
        if (characterDetails.ClassNameTMP) characterDetails.ClassNameTMP.text = character.GetName();
        if (characterDetails.LevelTMP) characterDetails.LevelTMP.text = character.GetLevel().ToString();
        if (characterDetails.HPTMP) characterDetails.HPTMP.text = character.GetCurrentHP().ToString();
        if (characterDetails.MAXHPTMP) characterDetails.MAXHPTMP.text = character.GetMaxHP().ToString();
        if (characterDetails.MPTMP) characterDetails.MPTMP.text = character.GetCurrentMP().ToString();
        if (characterDetails.MAXMPTMP) characterDetails.MAXMPTMP.text = character.GetMaxMP().ToString();
        if (characterDetails.Avatar)
        {
            if (characterDetails.Avatar.sprite == null)
                characterDetails.Avatar.sprite = CurrentSelected?.GetComponent<Image>().sprite;
        }
        characterDetails.characterType = character.GetCharacterType();
    }
    public void LevelUp(Character character)
    {
        character.LevelUp();
    }
    public void AddCharacter(Character character)
    {
        Characters.Add(character);
    }
    public void DeleteCharacter(int index)
    {
        Characters.RemoveAt(index);
    }
}
