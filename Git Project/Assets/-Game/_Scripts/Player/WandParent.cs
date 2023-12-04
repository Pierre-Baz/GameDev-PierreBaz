using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandParent : MonoBehaviour
{
    #region Properties

    public Vector2 Pointerposition { get; set; }

    #endregion

    #region References

    [Header("Reference")]
    public GameObject charge;
    public Animator animator;
    public float speed;
    public int damage;
    public float attackDelay;
    public float chargeDelay;

    private bool attackBlocked;
    private bool chargeBlocked;

    #endregion

    #region Collider Settings

    [Header("Collider Settings")]
    public Transform circleOrigin;
    public float radius;
    private GameObject Cinemachine;
    private CameraEffects cameraEffects;

    #endregion

    #region Initialization

    // Initialize CameraEffects reference
    void Start()
    {
        Cinemachine = GameObject.FindGameObjectWithTag("Cinemachine");
        cameraEffects = Cinemachine.GetComponent<CameraEffects>();
    }

    #endregion

    #region Update

    // Update the wand orientation based on pointer position
    private void Update()
    {
        transform.right = (Pointerposition - (Vector2)transform.position).normalized;
    }

    #endregion

    #region Attack

    // Perform the attack action
    public void Attack()
    {
        if (!attackBlocked)
        {
            cameraEffects.ShakeCamera();
            animator.SetTrigger("attack");
            SoundManager.PlaySound("wandWoosh");
            attackBlocked = true;
            StartCoroutine(DelayAttack());
        }
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        attackBlocked = false;
    }

    #endregion

    #region Charge

    public void Charge()
    {
        if (!chargeBlocked)
        {
            cameraEffects.ShakeCamera();
            animator.SetTrigger("charge");
            SoundManager.PlaySound("chargeUp");
            SoundManager.PlaySound("magicSmite");
            chargeBlocked = true;
            StartCoroutine(DelayCharge());
        }
    }

    private IEnumerator DelayCharge()
    {
        yield return new WaitForSeconds(chargeDelay);
        chargeBlocked = false;
    }

    #endregion

    #region Visualize Attack Range

    // Visualize the attack range in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    #endregion

    #region Detect Colliders

    public void DetectColliders()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(circleOrigin.position, radius);
        Collider2D closestCollider = FindClosestCollider(colliders);

        if (closestCollider != null)
        {
            HealthSystem closestHealth = closestCollider.GetComponent<HealthSystem>();
            closestHealth.GetHit(damage, transform.parent.gameObject);
        }
    }

    private Collider2D FindClosestCollider(Collider2D[] colliders)
    {
        Collider2D closestCollider = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {
            HealthSystem health = collider.GetComponent<HealthSystem>();
            if (health != null)
            {
                float distance = Vector2.Distance(circleOrigin.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestCollider = collider;
                }
            }
        }

        return closestCollider;
    }

    #endregion

    #region Projectile Instantiation

    public void InstantiateProjectile()
    {
        GameObject clone = Instantiate(charge, circleOrigin.position, Quaternion.identity);
        clone.SetActive(true);
        clone.GetComponent<Rigidbody2D>().velocity = circleOrigin.right * speed;
    }

    #endregion
}
