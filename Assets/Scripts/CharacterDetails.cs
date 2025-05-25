using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;

public class CharacterDetails : MonoBehaviour
{
    public TMP_Text ClassNameTMP, LevelTMP, HPTMP, MAXHPTMP, MPTMP, MAXMPTMP;
    public Image Avatar;
    public Button LevelUpButton, AttackButton, HealButton;
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
            if (GameManager.GM.CurrentState == State.GROUP_SELECTION ||
            GameManager.GM.CurrentState == State.OPPONENT_SELECTION)
            {
                GameManager.GM.DeleteCharacter(characterType);
                if (selectableCharacterButton) selectableCharacterButton.interactable = true;
                Destroy(gameObject);
            }
            if (GameManager.GM.CurrentState == State.TARGET_SELECTION)
            {
                Character target = GameManager.GM.SetTarget(GameManager.GM.GetCharacter(characterType));
                if (GameManager.GM.CurrentAction == Action.ATTACK)
                {
                    GameManager.GM.Attacker.ApplyDamage(target);
                    GameManager.GM.CurrentAction = Action.NONE;
                }
                if (GameManager.GM.CurrentAction == Action.HEAL)
                {
                    GameManager.GM.CurrentAction = Action.NONE;
                }
                GameManager.GM.FillCharacterDetails(this, target);
                GameManager.GM.CurrentState = State.DEFAULT;
            }
        });
        LevelUpButton?.onClick.AddListener(() =>
        {
            if (!GameManager.GM) return;

            GameManager.GM.LevelUp(GameManager.GM.GetCharacter(characterType));
            GameManager.GM.FillCharacterDetails(this, characterType);

        });
        AttackButton?.onClick.AddListener(() =>
        {
            if (GameManager.GM.CurrentState == State.DEFAULT)
            {
                GameManager.GM.Attacker = GameManager.GM.GetCharacter(characterType);
                GameManager.GM.CurrentState = State.TARGET_SELECTION;
                GameManager.GM.CurrentAction = Action.ATTACK;
                
            }
        });
        HealButton?.onClick.AddListener(() =>
        {
            if (GameManager.GM.CurrentState == State.DEFAULT)
            {
                GameManager.GM.CurrentAction = Action.HEAL;
                GameManager.GM.CurrentState = State.TARGET_SELECTION;
                
            }
        });
    }

    public int GetSiblingIndex()
    {
        return transform.GetSiblingIndex();
    }
}
