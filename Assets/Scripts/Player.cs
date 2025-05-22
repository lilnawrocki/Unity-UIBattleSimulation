using System;
using UnityEngine;

public class Player : Character
{
    public Player(int level, CharacterType characterType) : base(level, characterType)
    {
        if (characterType == CharacterType.SWORDSMAN)
        {
            name = "Swordsman";
            maxHP = Mathf.FloorToInt(level * level * 0.75f + 52);
            maxMP = level * 7 + 11;

        }
        if (characterType == CharacterType.MAGE)
        {
            name = "Mage";
            maxHP = Mathf.FloorToInt(level * level * 0.5f + level + 31.5f);
            maxMP = level * 15 + 32;

        }
        if (characterType == CharacterType.BACKEND_ENGINEER)
        {
            name = "Backend Engineer";
            maxHP = Mathf.FloorToInt(level * level * 0.95f + level + 36);
            maxMP = level * 12 + 24;

        }

        currentHP = maxHP;
        currentMP = maxMP;
    }

    public override int CalculateMaxHP(int level, CharacterType characterType)
    {
        int maxHP = 0;
        if (characterType == CharacterType.SWORDSMAN)
        {
            maxHP = Mathf.FloorToInt(level * level * 0.75f + 52);
        }
        if (characterType == CharacterType.MAGE)
        {
            maxHP = Mathf.FloorToInt(level * level * 0.5f + level + 31.5f);
        }
        if (characterType == CharacterType.BACKEND_ENGINEER)
        {
            maxHP = Mathf.FloorToInt(level * level * 0.95f + level + 36);
        }
        return maxHP;
    }

    public override int CalculateMaxMP(int level, CharacterType characterType)
    {
        int maxMP = 0;

        if (characterType == CharacterType.SWORDSMAN)
        {
            maxMP = level * 7 + 11;
        }
        if (characterType == CharacterType.MAGE)
        {
            maxMP = level * 15 + 32;
        }
        if (characterType == CharacterType.BACKEND_ENGINEER)
        {
            maxMP = level * 12 + 24;
        }
        return maxMP;
    }
    public override int ExpToNextLevel()
    {
        throw new System.NotImplementedException();
    }

    public override void ApplyDamage()
    {
        throw new System.NotImplementedException();
    }
}
