using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableMembers : MonoBehaviour
{
    List<SelectableCharacter> selectableCharacters = new List<SelectableCharacter>();
    void Awake()
    {

    }

    void OnEnable()
    {
        selectableCharacters.AddRange(GetComponentsInChildren<SelectableCharacter>());
        if (!GameManager.GM)
            return;
    }
}
