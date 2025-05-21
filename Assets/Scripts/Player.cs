public class Player : Character
{
    public Player(string name, int hp, int mp, int level, CharacterType characterType) : base(name, hp, mp, level, characterType)
    {

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
