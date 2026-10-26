using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    Weapon weapon;
    [SerializeField] WeaponSO weaponSO;
    float initTime;
    private void Start()
    {
        weapon = FindFirstObjectByType<Weapon>();
        initTime = 0;
    }   
    private void Update()
    {
        initTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.F))
        {
            if(initTime >= weaponSO.FireRate)
            {
                weapon.Shoot(weaponSO);
                initTime = 0;
            }
        }
    }
    public void SwitchWeapon(WeaponSO weaponSO)
    {
        Debug.Log("Weapon Changed");
    }
}
