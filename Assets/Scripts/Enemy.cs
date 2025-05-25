using UnityEngine;

public class Enemy : Character
{
    public Enemy(int level, CharacterType characterType) : base(level, characterType)
    {
        if (characterType == CharacterType.PINK_BEAN)
        {
            name = "Pink Bean";
            maxHP = Mathf.FloorToInt(level * level * 0.75f + level + 120);
            maxMP = level * 30 + 24;
            damage = Mathf.FloorToInt(level * 5 + 1.8f);
            healAmount = level * 5 + 7;
        }
        if (characterType == CharacterType.HORNY_MUSHROOM)
        {
            name = "Horny Mushroom";
            maxHP = Mathf.FloorToInt(level * level * 0.23f + level + 35);
            maxMP = level * 8 + 4;
            damage = Mathf.FloorToInt(level * 1.25f + 5);
            healAmount = level * 2 + 1;
        }
        if (characterType == CharacterType.SLIME)
        {
            name = "Slime";
            maxHP = Mathf.FloorToInt(level * level * 0.18f + level + 12);
            maxMP = level * 3 + 8;
            damage = Mathf.FloorToInt(level * 0.75f + 4.5f);
            healAmount = level * 2 + 6;
        }

        currentHP = maxHP;
        currentMP = maxMP;
        MPcost = Mathf.FloorToInt(level * 0.25f + 4);
    }

    public override int CalculateMaxHP(int level, CharacterType characterType)
    {
        int maxHP = 0;
        if (characterType == CharacterType.PINK_BEAN)
        {
            maxHP = Mathf.FloorToInt(level * level * 0.75f + level + 120);
        }
        if (characterType == CharacterType.HORNY_MUSHROOM)
        {
            maxHP = Mathf.FloorToInt(level * level * 0.23f + level + 35);
        }
        if (characterType == CharacterType.SLIME)
        {
            maxHP = Mathf.FloorToInt(level * level * 0.18f + level + 12);
        }
        return maxHP;
    }

    public override int CalculateMaxMP(int level, CharacterType characterType)
    {
        int maxMP = 0;
        if (characterType == CharacterType.PINK_BEAN)
        {
            maxMP = level * 30 + 24;
        }
        if (characterType == CharacterType.HORNY_MUSHROOM)
        {
            maxMP = level * 8 + 4;
        }
        if (characterType == CharacterType.SLIME)
        {
            maxMP = level * 3 + 8;
        }
        return maxMP;
    }
    public override int CalculateDamage(int level, CharacterType characterType)
    {
        int damage = 0;
        if (characterType == CharacterType.PINK_BEAN)
        {
            damage = Mathf.FloorToInt(level * 5 + 1.8f);
        }
        if (characterType == CharacterType.HORNY_MUSHROOM)
        {
            damage = Mathf.FloorToInt(level * 1.25f + 5);
        }
        if (characterType == CharacterType.SLIME)
        {
            damage = Mathf.FloorToInt(level * 0.75f + 4.5f);
        }
        return damage;
    }

    public override int CalculateHealAmount(int level, CharacterType characterType)
    {
        int healAmount = 0;
        if (characterType == CharacterType.PINK_BEAN)
        {
            healAmount = level * 5 + 7;
        }
        if (characterType == CharacterType.HORNY_MUSHROOM)
        {
            healAmount = level * 2 + 1;
        }
        if (characterType == CharacterType.SLIME)
        {
            healAmount = level * 2 + 6;
        }
        return healAmount;
    }

    public override int CalculateMPCost(int level)
    {
        return Mathf.FloorToInt(level * 0.25f + 4);
    }
}
