using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    [SerializeField] GameObject target;

    NavMeshAgent agent;
    EnemyHealth em;
    PlayerHealth ph;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        em = GetComponent<EnemyHealth>();
    }
    private void Start()
    {
        ph = FindFirstObjectByType<PlayerHealth>();
    }
    private void Update()
    {
        agent.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            ph?.TakeDamage(20);
            em.SelfDestroy();
        }
    }
}
