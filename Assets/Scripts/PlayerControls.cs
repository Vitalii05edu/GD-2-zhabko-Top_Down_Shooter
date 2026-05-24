using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Vector2 mousePosition;
    public Rigidbody2D rb;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 10f;

    public AudioClip shootSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            if (shootSound != null)
            {
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
            }
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}