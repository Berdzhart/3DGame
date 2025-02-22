using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Besar damage yang diberikan oleh peluru

    // Pastikan Collider peluru disetting sebagai Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah objek yang terkena memiliki komponen HealthManager
        HealthManager targetHealth = other.GetComponent<HealthManager>();
        if(targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }
        
        // Hancurkan peluru setelah mengenai target
        Destroy(gameObject);
    }
}
