using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class CharacterDetails : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text ClassNameTMP, LevelTMP, HPTMP, MAXHPTMP, MPTMP, MAXMPTMP;
    public Image Avatar;
    public Button LevelUpButton;
    public CharacterType characterType;
    public Button selectableCharacterButton;
    Button thisButton;
    void Awake()
    {
        thisButton = GetComponent<Button>();
    }

    void Start()
    {
        thisButton?.onClick.AddListener(() =>
        {
            if (!GameManager.GM) return;
            if (GameManager.GM.CurrentState == State.DEFAULT) return;
            
            GameManager.GM.DeleteCharacter(characterType);
            if (selectableCharacterButton) selectableCharacterButton.interactable = true;
            Destroy(gameObject);
        });
        LevelUpButton?.onClick.AddListener(() => 
        {
            if (GameManager.GM)
            {
                GameManager.GM.LevelUp(GameManager.GM.GetCharacter(characterType));
                GameManager.GM.FillCharacterDetails(this, characterType);
            }
        });
    }

    public int GetSiblingIndex()
    {
        return transform.GetSiblingIndex();
    }
}
