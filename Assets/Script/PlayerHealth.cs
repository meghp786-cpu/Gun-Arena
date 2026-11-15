using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int Health = 100;
    [SerializeField] GameObject TheEndUI;
    [SerializeField] TMP_Text Healthtext;

    private void Update()
    {
        Healthtext.text = Health.ToString();
        if (Health <= 0)
        {
            SelfDestroy();
        }
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        Debug.Log("Player health: " + Health);
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
        TheEndUI.SetActive(true);
    }
}
