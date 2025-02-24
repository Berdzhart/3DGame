using UnityEngine;
using System.Collections;

public class DisableOnTrigger : MonoBehaviour
{
    public float disableDuration = 3f; // How long to disable the mechanic
    private PlayerWeapon shootingScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the player has the "Player" tag
        {
            shootingScript = other.GetComponent<PlayerWeapon>();
            if (shootingScript != null)
            {
                StartCoroutine(DisableJumpRoutine());
            }
        }
    }

    private IEnumerator DisableJumpRoutine()
    {
        shootingScript.canShoot = false; // Disable the mechanic
        yield return new WaitForSeconds(disableDuration); // Wait for the duration
        shootingScript.canShoot = true; // Re-enable the mechanic
    }
}

