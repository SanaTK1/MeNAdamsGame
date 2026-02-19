using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;

    private float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
