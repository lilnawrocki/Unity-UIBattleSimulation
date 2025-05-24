using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public State CurrentState = 0;
    public GameObject CurrentSelected;
    public GameObject CharacterDetailsPanelPrefab;
    public Transform SelectedGroupMembers, SelectedOpponents;
    public Transform MainGroup, MainOpponents;
    public List<Character> AllCharacters = new List<Character>();
    public List<Character> PartyCharacters = new List<Character>();
    public List<Character> OpponentCharacters = new List<Character>();
    public List<SelectableCharacter> SelectedSelectable = new List<SelectableCharacter>();
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
        return character;
    }
    public GameObject CreateCharacterPanel()
    {
        if (!CharacterDetailsPanelPrefab || !SelectedGroupMembers || !SelectedOpponents) return null;

        if (CurrentState == State.GROUP_SELECTION)
        {
            if (SelectedGroupMembers.childCount < 3)
            {
                return Instantiate(CharacterDetailsPanelPrefab, SelectedGroupMembers);
            }
        }
        if (CurrentState == State.OPPONENT_SELECTION)
        {
            if (SelectedOpponents.childCount < 3)
            {
                return Instantiate(CharacterDetailsPanelPrefab, SelectedOpponents);
            }

        }
        return null;
    }
    public void AddCharacterToLists(Character character)
    {
        
        if (CurrentState == State.GROUP_SELECTION)
        {
            if (!PartyCharacters.Contains(character))
                PartyCharacters.Add(character);
        }
        else if (CurrentState == State.OPPONENT_SELECTION)
        {
            if (!OpponentCharacters.Contains(character))
                OpponentCharacters.Add(character);
        }
        
        if (!AllCharacters.Contains(character))
            AllCharacters.Add(character);
        
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
        
        if (CurrentState == State.GROUP_SELECTION)
        {
            for (int i = 0; i < PartyCharacters.Count; i++)
            {
                if (PartyCharacters.ElementAt(i).GetCharacterType() == characterType)
                {
                    PartyCharacters.RemoveAt(i);
                }
            }
        }
        if (CurrentState == State.OPPONENT_SELECTION)
        {
            for (int i = 0; i < OpponentCharacters.Count; i++)
            {
                if (OpponentCharacters.ElementAt(i).GetCharacterType() == characterType)
                {
                    OpponentCharacters.RemoveAt(i);
                }
            }
        }
        
    }
    //---------------------OLD FUNCTIONS-----------------//

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
        characterDetails.characterType = character.GetCharacterType();
    }

    public void FillCharacterDetails(CharacterDetails characterDetails, Character character)
    {
        if (!characterDetails) return;
        if (characterDetails.ClassNameTMP) characterDetails.ClassNameTMP.text = character.GetName();
        if (characterDetails.LevelTMP) characterDetails.LevelTMP.text = character.GetLevel().ToString();
        if (characterDetails.HPTMP) characterDetails.HPTMP.text = character.GetCurrentHP().ToString();
        if (characterDetails.MAXHPTMP) characterDetails.MAXHPTMP.text = character.GetMaxHP().ToString();
        if (characterDetails.MPTMP) characterDetails.MPTMP.text = character.GetCurrentMP().ToString();
        if (characterDetails.MAXMPTMP) characterDetails.MAXMPTMP.text = character.GetMaxMP().ToString();
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
    public Button GetSelectableButton(List<SelectableCharacter> selectableList, CharacterType characterType)
    {
        for (int i = 0; i < selectableList.Count; i++)
        {
            if (selectableList.ElementAt(i).characterType == characterType)
            {
                //Button button = selectableList.ElementAt(i).GetComponent<Button>();
                return selectableList.ElementAt(i).GetComponent<Button>();
            }
        }
        return null;
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

    public void DebugCharacterLists()
    {
        Debug.Log($"All characters: {AllCharacters.Count}");
        Debug.Log($"Party characters: {PartyCharacters.Count}");
        Debug.Log($"Opponent characters: {OpponentCharacters.Count}");
    }
}
