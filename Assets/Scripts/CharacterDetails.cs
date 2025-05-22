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

    int siblingIndex;
    Button button;

    void Awake()
    {
        siblingIndex = transform.GetSiblingIndex();
        button = GetComponent<Button>();
    }

    void Start()
    {
        button?.onClick.AddListener(delegate
        {
            if (GameManager.GM)
            {
                GameManager.GM.DeleteCharacter(transform.GetSiblingIndex());
                GameManager.GM.SelectedSelectable.ElementAt(transform.GetSiblingIndex()).interactable = true;
                GameManager.GM.SelectedSelectable.RemoveAt(transform.GetSiblingIndex());
            }
            Destroy(gameObject);
        });
        LevelUpButton?.onClick.AddListener(delegate
        {
            if (GameManager.GM)
            {
                GameManager.GM.LevelUp(GameManager.GM.Characters.ElementAt(transform.GetSiblingIndex()));
                GameManager.GM.FillCharacterDetails(this);
            }
        });
    }

    public int GetSiblingIndex()
    {
        return transform.GetSiblingIndex();
    }

    public int GetStaticSiblingIndex()
    {
        return siblingIndex;
    }
}
