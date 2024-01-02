using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a bullet at the fire point position and rotation
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
    }
}