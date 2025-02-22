using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    
    // Referensi ke script HealthBar
    public HealthBar healthBarUI;

    void Start()
    {
        currentHealth = maxHealth;
        if(healthBarUI != null)
        {
            healthBarUI.SetMaxHealth(maxHealth);
        }
    }

    // Fungsi untuk menerima damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        // Update tampilan health bar
        if(healthBarUI != null)
        {
            healthBarUI.SetHealth(currentHealth);
        }

        // Jika health habis, bisa tambahkan logika kematian
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " telah mati!");
        // Tambahkan logika kematian seperti animasi, restart, dll.
    }
}
