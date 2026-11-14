using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    [SerializeField] float rotationspeed = 100f;
    const string Player_Tag = "Player";

    private void Update()
    {
        transform.Rotate(0f, rotationspeed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Player_Tag))
        {
            ActiveWeapon activeweapon =other.gameObject.GetComponentInChildren<ActiveWeapon>();
            OnPickUp(activeweapon);
            Destroy(gameObject);
        }
    }
    protected abstract void OnPickUp(ActiveWeapon activeWeapon);
}
