public abstract class Character
{
    protected string name;
    protected int hp;
    protected int mp;
    protected int level;
    protected int currentExp = 0;
    protected int expToNextLevel;

    protected CharacterType characterType;

    public Character(string name, int hp, int mp, int level, CharacterType characterType)
    {
        this.name = name;
        this.hp = hp;
        this.mp = mp;
        this.level = level;
        this.characterType = characterType;
    }

    public abstract int ExpToNextLevel();
    public abstract void ApplyDamage();
    
}