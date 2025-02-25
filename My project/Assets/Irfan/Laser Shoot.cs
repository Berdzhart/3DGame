using UnityEngine;


public class EnemyShooter : MonoBehaviour
{
    public GameObject laserPrefab;  // Assign bullet prefab
    public Transform firePoint;      // Where the bullet spawns
    [SerializeField] private float FireRate = 2f;
    private float CountDownBetweenFire = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;

    }

    private void Update()
    {
        if (player != null)
        {

            if (CountDownBetweenFire <= 0)
            {

                Shoot();
                CountDownBetweenFire = 1f / FireRate;
            }
            CountDownBetweenFire -= Time.deltaTime;

        }

    }
   
    void Shoot()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Laser bulletScript = laser.GetComponent<Laser>();
        Vector3 direction = (player.position - firePoint.position) * 90f ;
        laser.transform.rotation = Quaternion.LookRotation(direction);

        // Make the laser move
        Laser laserScript = laser.GetComponent<Laser>();
        if (laserScript)
        {
            laserScript.SetDirection(direction);
        }
    }
}