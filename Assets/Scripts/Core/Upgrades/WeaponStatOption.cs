public class WeaponStatOption : UpgradeOption
{
    public string WeaponName => _weaponName;
    public Stat Stat => _stat;
    string _weaponName;
    Stat _stat;

    public WeaponStatOption(string weaponName, Stat stat)
    {
        _weaponName = weaponName;
        _stat = stat;
    }

    public override void AssignTo(SO_UpgradeOptionData data)
    {
        data.SetValuesWeaponStat(WeaponName, _stat);
    }
}
