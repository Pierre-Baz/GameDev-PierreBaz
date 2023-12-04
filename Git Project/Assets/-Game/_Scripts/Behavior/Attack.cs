using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    #region Serialized Fields

    [Header("Events")]
    public UnityEvent OnAttack;
    public UnityEvent Stop;

    [Header("Attack Parameters")]
    [SerializeField] private float detectionRadius;
    [SerializeField] private float attackDelay;

    #endregion

    #region Private Variables

    private Transform player;
    private LayerMask playerLayer;
    private Animator animator;
    private float elapsedTime;

    #endregion

    #region Unity Callbacks

    private void Start()
    {
        InitializeReferences();
    }

    private void Update()
    {
        HandleAttack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    #endregion

    #region Initialization

    private void InitializeReferences()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        playerLayer = LayerMask.NameToLayer("Player");
    }

    #endregion

    #region Attack Handling

    private void HandleAttack()
    {
        bool playerInRange = Physics2D.OverlapCircle(transform.position, detectionRadius, 1 << playerLayer);
        
        if (playerInRange && elapsedTime >= attackDelay)
        {
            elapsedTime = 0;
            PerformAttack();
            SoundManager.PlaySound("wandWoosh");
        }

        if (elapsedTime < attackDelay)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    private void PerformAttack()
    {
        OnAttack?.Invoke();
        Stop?.Invoke();
        animator.SetBool("Speed", false);
    }

    #endregion
}
