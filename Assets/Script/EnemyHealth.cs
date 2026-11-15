using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int Health = 3;
    [SerializeField] GameObject explosionFX;

    private void Update()
    {
        if(Health <= 0)
        {
           SelfDestroy();
        }
    }

    public void TakeDamage( int Damage)
    {
        Health -= Damage;
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
        Instantiate(explosionFX, transform.position, Quaternion.identity);
    }
}
