using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable), typeof(Button))]
public class SelectableCharacter : MonoBehaviour
{
    public CharacterType characterType;
    public Transform parent;
    Button button;
    bool capacityReached = false;

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
                //GameManager.GM.RemoveFromNotSelectedSelectable(button);
                if (button) button.interactable = false;
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
