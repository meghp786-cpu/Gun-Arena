using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int Health = 3;
    [SerializeField] GameObject explosionFX;

    private void Update()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionFX, transform.position, Quaternion.identity);
        }
    }

    public void TakeDamage( int Damage)
    {
        Health -= Damage;
    }
}
