using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable), typeof(Button))]
public class SelectableCharacter : MonoBehaviour
{
    public CharacterType characterType;
    public Transform parent;
    Button button;
    void Awake()
    {
        button = GetComponent<Button>();

    }
    void Start()
    {
        button?.onClick.AddListener(delegate
        {
            if (!GameManager.GM || !parent) return;

            if (parent.childCount < 3)
            {
                GameManager.GM.CreateCharacter(characterType);
                GameManager.GM.InstantiateCharacterPanel(characterType, GameManager.GM.CharacterDetailsPanelPrefab, parent);
                GameManager.GM.SelectedSelectable.Add(button);
                if (button) button.interactable = false;
                if (GameManager.GM.CurrentState == State.GROUP_SELECTION)
                    GameManager.GM.AddCharacterFromAll(characterType, GameManager.GM.PartyCharacters);
                if (GameManager.GM.CurrentState == State.OPPONENT_SELECTION)
                    GameManager.GM.AddCharacterFromAll(characterType, GameManager.GM.OpponentCharacters);
            }
        });
    }

    void OnEnable()
    {
        if (button) button.interactable = true;
        if (!GameManager.GM) return;
        foreach (Character character in GameManager.GM.AllCharacters)
        {
            if (character.GetCharacterType() == characterType)
            {
                if (button) button.interactable = false;
            }       
        }
    }
}
