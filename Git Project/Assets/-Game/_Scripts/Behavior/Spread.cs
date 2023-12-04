using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spread : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    public float speed;
    private Transform player;
    public Transform firePos;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    public void ShootMultipleProjectiles()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;

        // Calculate the initial rotation angle for the first projectile
        float initialAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Create 8 projectiles in equally spaced directions
        for (int i = 0; i < 8; i++)
        {
            // Calculate the angle for the current projectile
            float angle = initialAngle + i * 45f;

            // Calculate the direction vector from the angle
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            GameObject clone = Instantiate(projectile, firePos.position, Quaternion.identity);
            clone.SetActive(true);

            Rigidbody2D rb2d = clone.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.velocity = direction * speed;
            }
        }
    }
}
