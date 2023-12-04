using UnityEngine;

public class Charge : MonoBehaviour
{
    #region Serialized Fields

    [Header("Projectile Properties")]
    [SerializeField] private int damage;

    #endregion

    #region Collision Handling

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            HealthSystem health = collider.GetComponent<HealthSystem>();
            if (health != null)
            {
                health.GetHit(damage, gameObject);
            }
        }
        Destroy(gameObject);
    }

    #endregion
}
