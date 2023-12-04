using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public int damage;
    public float radius;
    public Transform CPos;

    public void melee()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(CPos.position, radius))
        {
            HealthSystem health = collider.GetComponent<HealthSystem>();
            if (health != null)
            {
                health.GetHit(damage, transform.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 position = CPos.position;
        Gizmos.DrawWireSphere(position, radius);
    }
}
