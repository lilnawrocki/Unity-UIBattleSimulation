using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class CharacterDetails : MonoBehaviour
{
    public TMP_Text ClassNameTMP, LevelTMP, HPTMP, MAXHPTMP, MPTMP, MAXMPTMP;
    public Image Avatar;
    public Button LevelUpButton;
    public CharacterType characterType;
    Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    void Start()
    {
        button?.onClick.AddListener(delegate
        {
            if (GameManager.GM)
            {
                GameManager.GM.DeleteCharacter(characterType);
                Button selectedButton = GameManager.GM.GetButton(GameManager.GM.SelectedSelectable, characterType);
                if (selectedButton == null) return;
                selectedButton.interactable = true;
                GameManager.GM.RemoveFromSelectedSelectable(characterType);
            }
            Destroy(gameObject);
        });
        LevelUpButton?.onClick.AddListener(delegate
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
