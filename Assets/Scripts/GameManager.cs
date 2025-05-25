using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public State CurrentState = 0;
    public Action CurrentAction = 0;
    public Button CurrentSelected;
    public GameObject CharacterDetailsPanelPrefab;
    public Transform SelectedGroupMembers, SelectedOpponents;
    public Transform MainGroup, MainOpponents;
    public List<Character> AllCharacters = new List<Character>();
    public List<Character> PartyCharacters = new List<Character>();
    public List<Character> OpponentCharacters = new List<Character>();
    public Character Target;
    public Character Attacker;
    public Button SelectedAttackButton, SelectedHealButton;
    public CharacterDetails SelectedCharacterDetails;
    void Awake()
    {
        GM = this;
    }
    public void SetCurrentSelectedButton(Button button)
    {
        CurrentSelected = button;
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
            if (SelectedGroupMembers.childCount < 3 && PartyCharacters.Count < 3)
            {
                return Instantiate(CharacterDetailsPanelPrefab, SelectedGroupMembers);
            }
        }
        if (CurrentState == State.OPPONENT_SELECTION)
        {
            if (SelectedOpponents.childCount < 3 && OpponentCharacters.Count < 3)
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
    public void SetState(int state)
    {
        CurrentState = (State)state;
    }
    public void InitGame()
    {
        while (SelectedGroupMembers.childCount > 0)
        {
            SelectedGroupMembers.GetChild(0).SetParent(MainGroup);
        }

        while (SelectedOpponents.childCount > 0)
        {
            SelectedOpponents.GetChild(0).SetParent(MainOpponents);
        }
    }
}
