using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager GM = null;
    public State CurrentState = 0;
    public GameObject CurrentSelected = null;
    public GameObject CharacterDetailsPanelPrefab = null;
    public GameObject AvailableCharactersPartyPanel = null;
    public GameObject AvailableCharactersOpponentsPanel = null;
    public Transform SelectedPartyParent = null;

    public List<Character> AllCharacters = new List<Character>();
    public List<Character> PartyCharacters = new List<Character>();
    public List<Character> OpponentCharacters = new List<Character>();
    public List<Button> SelectedSelectable = new List<Button>();
    void Awake()
    {
        GM = this;
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
        AllCharacters.Add(character);
        return character;
    }
    public Character CreateCharacter(CharacterType characterType, List<Character> characterList)
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
        characterList.Add(character);
        return character;
    }
    public void InstantiateCharacterPanel(CharacterType characterType, GameObject panelPrefab, Transform parent)
    {
        GameObject characterDetailsPanelObject;
        if (panelPrefab && parent)
        {
            if (parent.childCount < 3)
            {
                characterDetailsPanelObject = Instantiate(panelPrefab, parent);
                CharacterDetails characterDetails = characterDetailsPanelObject.GetComponent<CharacterDetails>();
                FillCharacterDetails(characterDetails, characterType);
            }

        }
    }

    public void FillCharacterDetails(CharacterDetails characterDetails, CharacterType characterType)
    {
        Character character = GetCharacter(characterType);
        if (character == null) return;
        if (characterDetails.ClassNameTMP) characterDetails.ClassNameTMP.text = character?.GetName();
        if (characterDetails.LevelTMP) characterDetails.LevelTMP.text = character?.GetLevel().ToString();
        if (characterDetails.HPTMP) characterDetails.HPTMP.text = character?.GetCurrentHP().ToString();
        if (characterDetails.MAXHPTMP) characterDetails.MAXHPTMP.text = character?.GetMaxHP().ToString();
        if (characterDetails.MPTMP) characterDetails.MPTMP.text = character?.GetCurrentMP().ToString();
        if (characterDetails.MAXMPTMP) characterDetails.MAXMPTMP.text = character?.GetMaxMP().ToString();
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
    public Character GetCharacter(CharacterType characterType)
    {
        foreach (Character character in AllCharacters)
        {
            if (character.GetCharacterType() == characterType)
            {
                return character;
            }
        }

        return null;
    }
    public Button GetButton(List<Button> buttonList, CharacterType characterType)
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (buttonList.ElementAt(i).GetComponent<SelectableCharacter>().characterType == characterType)
            {
                return buttonList.ElementAt(i);
            }
        }
        return null;
    }
    public void DeleteCharacter(int index)
    {
        AllCharacters.RemoveAt(index);
    }
    public void DeleteCharacter(CharacterType characterType)
    {
        for (int i = 0; i < AllCharacters.Count; i++)
        {
            if (AllCharacters.ElementAt(i).GetCharacterType() == characterType)
            {
                AllCharacters.RemoveAt(i);
            }
        }
    }
    public void AddCharacterFromAll(CharacterType characterType, List<Character> characters)
    {
        foreach (Character character in AllCharacters)
        {
            if (character.GetCharacterType() == characterType)
            {
                characters.Add(character);
            }
        }
    }
    public void DeleteCharacter(CharacterType characterType, List<Character> characters)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters.ElementAt(i).GetCharacterType() == characterType)
            {
                characters.RemoveAt(i);
            }
        }
    }
    public void RemoveFromSelectedSelectable(CharacterType characterType)
    {
        for (int i = 0; i < SelectedSelectable.Count; i++)
        {
            if (SelectedSelectable.ElementAt(i).GetComponent<SelectableCharacter>().characterType == characterType)
            {
                SelectedSelectable.RemoveAt(i);
            }
        }
    }
    public void SetState(int state)
    {
        CurrentState = (State)state;
    }
}
