public abstract class Character
{
    protected string name;
    protected int currentHP;
    protected int maxHP;
    protected int currentMP;
    protected int maxMP;
    protected int level;
    protected int currentExp = 0;
    protected int expToNextLevel;

    protected CharacterType characterType;

    public Character(int level, CharacterType characterType)
    {
        this.level = level;
        this.characterType = characterType;
    }

    public abstract int ExpToNextLevel();
    public abstract void ApplyDamage();

    public abstract int CalculateMaxHP(int level, CharacterType characterType);
    public abstract int CalculateMaxMP(int level, CharacterType characterType);

    public int GetMaxHP()
    {
        return maxHP;
    }

    public int GetMaxMP()
    {
        return maxMP;
    }

    public int GetLevel()
    {
        return level;
    }

    public string GetName()
    {
        return name;
    }

    public void SetCurrentHP(int value)
    {
        currentHP = value;
    }

    public void SetCurrentMP(int value)
    {
        currentMP = value;
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    public int GetCurrentMP()
    {
        return currentMP;
    }
    public void LevelUp()
    {
        if (level < 99)
        {
            level++;
            maxHP = CalculateMaxHP(level, characterType);
            maxMP = CalculateMaxMP(level, characterType);
        } 
    }
    public CharacterType GetCharacterType()
    {
        return characterType;
    }
}