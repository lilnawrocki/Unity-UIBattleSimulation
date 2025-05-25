using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable), typeof(Button))]
public class SelectableCharacter : MonoBehaviour
{
    public CharacterType characterType;
    public Transform parent;
    Button thisButton;
    Image thisImage;
    void Awake()
    {
        thisButton = GetComponent<Button>();
        thisImage = GetComponent<Image>();
    }
    void Start()
    {
        thisButton?.onClick.AddListener(() =>
        {
            if (!GameManager.GM) return;
            Character newCharacter = GameManager.GM.CreateCharacter(characterType);
            GameObject characterPanel = GameManager.GM.CreateCharacterPanel();
            if (characterPanel)
            {
                CharacterDetails characterDetails = characterPanel.GetComponent<CharacterDetails>();
                GameManager.GM.FillCharacterDetails(characterDetails, newCharacter);
                characterDetails.selectableCharacterButton = thisButton;
                characterDetails.Avatar.sprite = thisImage.sprite;
                if (thisButton) thisButton.interactable = false;
                GameManager.GM.AddCharacterToLists(newCharacter);
            }      
            
        });
    }
    void OnEnable()
    {
        if (thisButton) thisButton.interactable = true;
        foreach (Character character in GameManager.GM.AllCharacters)
        {
            if (character.GetCharacterType() == characterType)
            {
               if (thisButton) thisButton.interactable = false;
            }
        }
        
    }
}
