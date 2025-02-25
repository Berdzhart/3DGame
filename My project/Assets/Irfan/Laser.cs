using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5;

    private Vector3 moveDirection;

    public void SetDirection(Vector3 direction)
    {
        moveDirection = (direction - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime; // Move laser forward
    }

    void Start()
    {
        if (gameObject.name.Contains("(Clone)"))
        {
            Destroy(gameObject, lifetime);
        } // Destroy laser after a set time
    }
}