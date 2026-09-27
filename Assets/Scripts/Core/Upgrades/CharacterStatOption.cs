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
        data.SetValuesCharacterStat(_stat);
    }
}
