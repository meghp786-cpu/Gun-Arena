using UnityEngine;

public class Weapon : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] ParticleSystem muzzleFX;
    [SerializeField] GameObject HitFX;
    [SerializeField] LayerMask layermask;
    
    public void Shoot(WeaponSO weaponSO)
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity,layermask,QueryTriggerInteraction.Ignore))
        {
            muzzleFX.Play();
            Instantiate(HitFX, hit.point, Random.rotation);
            Debug.Log(hit.transform.gameObject.name);
            EnemyHealth eh = hit.transform.gameObject.GetComponent<EnemyHealth>();
            eh?.TakeDamage(weaponSO.Damage);
        }
    }
}
