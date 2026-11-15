using UnityEngine;

public class AmmoPickUp : PickUp
{
    [SerializeField]int ammo = 10;
    protected override void OnPickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.Changeammo(ammo);
    }
}
