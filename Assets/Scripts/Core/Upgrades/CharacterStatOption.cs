public class CharacterStatOption : UpgradeOption
{
    public Stat Stat => _stat;
    Stat _stat;

    public CharacterStatOption(Stat stat)
    {
        _stat = stat;
    }

    public override void AssignTo(SO_UpgradeOptionData data)
    {
        data.SetValues(this);
    }

    public override void Select()
    {
        Player player = GameStateManager.Instance.Player;
        Stat stat = player.Stats.Character.GetStat(_stat.Name);
        stat.LevelUp();
    }
}
