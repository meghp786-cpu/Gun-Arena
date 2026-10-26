using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    const string Player_Tag = "Player";
    ActiveWeapon activeWeapon;
    [SerializeField]WeaponSO weaponSO;

    private void Start()
    {
        activeWeapon = FindFirstObjectByType<ActiveWeapon>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(Player_Tag))
        {
            activeWeapon.SwitchWeapon(weaponSO);
            Destroy(gameObject);
        }  
    }
}
