using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
                Character target = GameManager.GM.GetCharacter(characterType);
                if (GameManager.GM.CurrentAction == Action.ATTACK)
                {
                    GameManager.GM.Attacker.ApplyDamage(target);
                    GameManager.GM.CurrentAction = Action.NONE;
                    GameManager.GM.SelectedAttackButton.interactable = true;
                }
                if (GameManager.GM.CurrentAction == Action.HEAL)
                {
                    GameManager.GM.Attacker.Heal(target);
                    GameManager.GM.CurrentAction = Action.NONE;
                    GameManager.GM.SelectedHealButton.interactable = true;
                    GameManager.GM.SelectedCharacterDetails.MPTMP.text = GameManager.GM.Attacker.GetCurrentMP().ToString();
                }
                GameManager.GM.FillCharacterDetails(this, target);
                GameManager.GM.CurrentState = State.DEFAULT;

            }
            Character thisCharacter = GameManager.GM.GetCharacter(characterType);
            if (thisCharacter?.GetCurrentHP() <= 0)
            {
                thisButton.interactable = false;
                LevelUpButton.interactable = false;
                AttackButton.interactable = false;
                HealButton.interactable = false;
            }
        });
        LevelUpButton?.onClick.AddListener(() =>
        {
            if (!GameManager.GM) return;

            GameManager.GM.LevelUp(GameManager.GM.GetCharacter(characterType));
            if (GameManager.GM.CurrentState == State.GROUP_SELECTION ||
            GameManager.GM.CurrentState == State.OPPONENT_SELECTION)
            {
                GameManager.GM.GetCharacter(characterType).SetCurrentHP(GameManager.GM.GetCharacter(characterType).GetMaxHP());
                GameManager.GM.GetCharacter(characterType).SetCurrentMP(GameManager.GM.GetCharacter(characterType).GetMaxMP());
            }
            
            GameManager.GM.FillCharacterDetails(this, GameManager.GM.GetCharacter(characterType));

        });
        AttackButton?.onClick.AddListener(() =>
        {
            if (GameManager.GM.CurrentState == State.DEFAULT)
            {
                GameManager.GM.Attacker = GameManager.GM.GetCharacter(characterType);
                GameManager.GM.CurrentState = State.TARGET_SELECTION;
                GameManager.GM.CurrentAction = Action.ATTACK;
                GameManager.GM.SelectedAttackButton = AttackButton;
                GameManager.GM.SelectedAttackButton.interactable = false;
            }
        });
        HealButton?.onClick.AddListener(() =>
        {
            if (GameManager.GM.CurrentState == State.DEFAULT)
            {
                GameManager.GM.Attacker = GameManager.GM.GetCharacter(characterType);
                GameManager.GM.CurrentState = State.TARGET_SELECTION;
                GameManager.GM.CurrentAction = Action.HEAL;
                GameManager.GM.SelectedHealButton = HealButton;
                GameManager.GM.SelectedHealButton.interactable = false;
                GameManager.GM.SelectedCharacterDetails = this;
                
            }
        });
    }
}
