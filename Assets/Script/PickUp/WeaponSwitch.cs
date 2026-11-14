using UnityEngine;

public class WeaponSwitch : PickUp
{    
    [SerializeField]WeaponSO weaponSO;

    protected override void OnPickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(weaponSO);
    }
}
