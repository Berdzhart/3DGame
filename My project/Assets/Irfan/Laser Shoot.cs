using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyShooter : MonoBehaviour
{
    public GameObject laserPrefab;  // Assign bullet prefab
    public Transform firePoint;      // Where the bullet spawns
    public float fireRateMin = 2f;   // Min time between shots
    public float fireRateMax = 4f;   // Max time between shots
    [SerializeField] private float FireRate = 2f;
    private float CountDownBetweenFire = 0f;
    [SerializeField] public Transform player;

    void Start()
    {
        
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        
        /*StartCoroutine(ShootRoutine());*/
        if (CountDownBetweenFire <= 0)
        {
            Shoot();
            CountDownBetweenFire = 1f / FireRate;
        }
        CountDownBetweenFire -= Time.deltaTime;
        

    }
    /*IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(fireRateMin, fireRateMax));
            Shoot();
        }
    }*/

    void Shoot()
    {
        if (player != null)
        {
            GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.transform.rotation);
            Laser bulletScript = laser.GetComponent<Laser>();
            Vector3 direction = (player.position - firePoint.position);
            laser.transform.rotation = Quaternion.LookRotation(direction);
            Debug.Log(player.transform.position);

            // Make the laser move
            Laser laserScript = laser.GetComponent<Laser>();
            if (laserScript)
            {
                laserScript.SetDirection(direction);
            }
        }
    }
}
