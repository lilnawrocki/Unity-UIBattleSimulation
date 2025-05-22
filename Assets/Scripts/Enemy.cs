using UnityEngine;

public class Enemy : Character
{
    int rewardExp;
    public Enemy(int level, CharacterType characterType) : base(level, characterType)
    {
        if (characterType == CharacterType.PINK_BEAN)
        {
            name = "Pink Bean";
            maxHP = Mathf.FloorToInt(level * level * 0.75f + level + 120);
            maxMP = level * 30 + 24;
        }
        if (characterType == CharacterType.HORNY_MUSHROOM)
        {
            name = "Horny Mushroom";
            maxHP = Mathf.FloorToInt(level * level * 0.23f + level + 35);
            maxMP = level * 8 + 4;
        }
        if (characterType == CharacterType.SLIME)
        {
            name = "Slime";
            maxHP = Mathf.FloorToInt(level * level * 0.18f + level + 12);
            maxMP = level * 3 + 8;
            //=A2*A2*0,18+A2+12
        }

        currentHP = maxHP;
        currentMP = maxMP;
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
    public override int ExpToNextLevel()
    {
        throw new System.NotImplementedException();
    }

    public override void ApplyDamage()
    {
        throw new System.NotImplementedException();
    }

    public int RewardExp(int level)
    {
        return 0;
    } 
}
