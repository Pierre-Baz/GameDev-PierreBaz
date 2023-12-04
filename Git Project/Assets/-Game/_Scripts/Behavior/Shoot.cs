using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
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
    public void shoot()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;

        GameObject clone = Instantiate(projectile, firePos.position, Quaternion.identity);
        clone.SetActive(true);

        Rigidbody2D rb2d = clone.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.velocity = directionToPlayer * speed;
        }
    }
}
