using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public class SelectableCharacter : MonoBehaviour
{
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
                if (GameManager.GM.SelectedSelectable.Count < 3)
                {
                    GameManager.GM.CreateCharacter(characterType);
                    GameManager.GM.InstantiateCharacterPanel(characterType);
                    GameManager.GM.SelectedSelectable.Add(button);
                    if (button) button.interactable = false;
                }
                    
            }

            
         });
    }
}
