using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] WeaponSO startingWeapon;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] GameObject zoomeffect;

    [Header("UI Text")]
    [SerializeField] TMP_Text currentAmmoUI;
    [SerializeField] TMP_Text totalAmmoUI;

    Weapon currentweapon;
    CinemachineVirtualCamera virtualCamera;

    int currentAmmo;
    float initTime;
    float defaultFOV;

    private void Start()
    {
        currentweapon = FindFirstObjectByType<Weapon>();
        SwitchWeapon(startingWeapon);
        //weapon = FindFirstObjectByType<Weapon>();
        virtualCamera = FindFirstObjectByType<CinemachineVirtualCamera>();
        initTime = 10;
        defaultFOV = virtualCamera.m_Lens.FieldOfView;
    }   
    private void Update()
    {
        initTime += Time.deltaTime;
        HandelShoot();
        HandelZoom();
    }

    private void HandelShoot()
    {
        if (Input.GetKey(KeyCode.F) && currentAmmo > 0)
        {
            if (initTime >= weaponSO.FireRate)
            {
                currentAmmo -= 1;
                currentAmmoUI.text = currentAmmo.ToString("D2");
                currentweapon.Shoot(weaponSO);
                initTime = 0;
            }
        }
    }

    private void HandelZoom() 
    {
        if (!weaponSO.canZoom) return;
        if (Input.GetKey(KeyCode.Z)) 
        {
            virtualCamera.m_Lens.FieldOfView = weaponSO.zoomFOV;
            zoomeffect.SetActive(true);
        }
        else 
        {
            virtualCamera.m_Lens.FieldOfView = defaultFOV;
            zoomeffect.SetActive(false);
        }
    }
    public void SwitchWeapon(WeaponSO weaponSO)
    {
        Debug.Log("Weapon Changed");
        if (currentweapon)
        {
            Destroy(currentweapon.gameObject);
        }
        totalAmmoUI.text = weaponSO.magazineAmmo.ToString("D2");
        currentAmmo = weaponSO.magazineAmmo;
        currentAmmoUI.text = weaponSO.magazineAmmo.ToString("D2");
        Weapon NewWeapon =Instantiate(weaponSO.EquipedWeapon,transform).GetComponent<Weapon>();
        currentweapon = NewWeapon;
        this.weaponSO = weaponSO;
    }
}
