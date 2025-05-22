public class Enemy : Character
{
    int rewardExp;
    public Enemy(int level, CharacterType characterType) : base(level, characterType)
    {
        if (characterType == CharacterType.PINK_BEAN)
        {
            this.name = "Pink Bean";
        }
        if (characterType == CharacterType.HORNY_MUSHROOM)
        {
            this.name = "Horny Mushroom";
        }
        if (characterType == CharacterType.SLIME)
        {
            this.name = "Slime";
        }
    }

    public override int CalculateMaxHP(int level, CharacterType characterType)
    {
        throw new System.NotImplementedException();
    }

    public override int CalculateMaxMP(int level, CharacterType characterType)
    {
        throw new System.NotImplementedException();
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
