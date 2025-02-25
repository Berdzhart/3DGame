using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField] GameObject playerDestroyedVFX;

    [SerializeField] bool isPlayer = false;

    MainMenu mainMenu;

    // Referensi ke script HealthBar
    public HealthBar healthBarUI;

    void Start()
    {
        mainMenu = FindFirstObjectByType<MainMenu>();

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
        Instantiate(playerDestroyedVFX, transform.position, Quaternion.identity);

        if (isPlayer)
        {
            mainMenu.ReloadLevel();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
