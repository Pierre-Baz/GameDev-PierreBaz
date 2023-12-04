using UnityEngine;

public class Collision : MonoBehaviour
{
    #region Serialized Fields

    [Header("Properties")]
    [SerializeField] private int damage;

    #endregion

    #region Collision Handling

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collider has the "Player" tag
        if (collider.gameObject.CompareTag("Player"))
        {
            // Attempt to get the HealthSystem component from the collider
            HealthSystem health = collider.GetComponent<HealthSystem>();
            
            // If the HealthSystem component exists, apply damage and destroy the object
            if (health != null)
            {
                health.GetHit(damage, gameObject);
                Destroy(gameObject);
            }
        }
    }

    #endregion
}
