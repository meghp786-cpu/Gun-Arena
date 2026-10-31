using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [Header ("Gun")]
    public GameObject EquipedWeapon;
    public int Damage;
    public float FireRate;
    public bool canZoom;
    public float zoomFOV;
}
