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
            damage = Mathf.FloorToInt(level * 3 + 0.4f);
            healAmount = level * 2 + 3;

        }
        if (characterType == CharacterType.MAGE)
        {
            name = "Mage";
            maxHP = Mathf.FloorToInt(level * level * 0.5f + level + 31.5f);
            maxMP = level * 15 + 32;
            damage = Mathf.FloorToInt(level * 2.1f + 0.8f);
            healAmount = level * 6 + 5;

        }
        if (characterType == CharacterType.BACKEND_ENGINEER)
        {
            name = "Backend Engineer";
            maxHP = Mathf.FloorToInt(level * level * 0.95f + level + 36);
            maxMP = level * 12 + 24;
            damage = Mathf.FloorToInt(level * 3.5f + 1);
            healAmount = level * 5 + 10;

        }

        currentHP = maxHP;
        currentMP = maxMP;
        MPcost = Mathf.FloorToInt(level * 0.5f + 3);
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
    public override int CalculateDamage(int level, CharacterType characterType)
    {
        int damage = 0;
        if (characterType == CharacterType.SWORDSMAN)
        {
            damage = Mathf.FloorToInt(level * 3 + 0.4f);
        }
        if (characterType == CharacterType.MAGE)
        {
            damage = Mathf.FloorToInt(level * 2.1f + 0.8f);
        }
        if (characterType == CharacterType.BACKEND_ENGINEER)
        {
            damage = Mathf.FloorToInt(level * 3.5f + 1);
        }
        return damage;
    }
    public override int CalculateHealAmount(int level, CharacterType characterType)
    {
        int healAmount = 0;
        if (characterType == CharacterType.SWORDSMAN)
        {
            healAmount = level * 2 + 3;
        }
        if (characterType == CharacterType.MAGE)
        {
            healAmount = level * 6 + 5;
        }
        if (characterType == CharacterType.BACKEND_ENGINEER)
        {
            healAmount = level * 5 + 10;
        }
        return healAmount;
    }
    public override int CalculateMPCost(int level)
    {
        return Mathf.FloorToInt(level * 0.5f + 3);
    }
}
