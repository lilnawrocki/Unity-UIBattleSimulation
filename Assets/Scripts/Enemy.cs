public class Enemy : Character
{
    int rewardExp;
    public Enemy(string name, int hp, int mp, int level, CharacterType characterType) : base(name, hp, mp, level, characterType)
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

    public int RewardExp(int level)
    {
        return 0;
    } 
}
