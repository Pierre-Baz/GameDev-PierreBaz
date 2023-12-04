using UnityEngine;
using UnityEngine.Events;

public class Chase : MonoBehaviour
{
    #region Events

    public UnityEvent Follow;
    public UnityEvent Stop;

    #endregion

    #region Serialized Fields

    [Header("Movement Parameters")]
    [SerializeField] private float chaseDistance;
    [SerializeField] private float stopDistance;

    #endregion

    #region Private Variables

    private Transform player;
    private Animator animator;
    private Vector3 originalScale;

    #endregion

    #region Unity Callbacks

    private void Start()
    {
        InitializeReferences();
        originalScale = transform.localScale;
    }

    private void Update()
    {
        HandleSprite();
        HandleChaseState();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }

    #endregion

    #region Initialization

    private void InitializeReferences()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    #endregion

    #region Chase Handling

    private void HandleChaseState()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(player.position, transform.position);

        if (distance < chaseDistance)
        {
            if (distance >= stopDistance)
            {
                Follow?.Invoke();
                animator.SetBool("Speed", true);
            }
            else
            {
                Stop?.Invoke();
                animator.SetBool("Speed", false);
            }
        }
        else
        {
            Stop?.Invoke();
            animator.SetBool("Speed", false);
        }
    }

    #endregion

    #region Sprite Handling

    private void HandleSprite()
    {
        if (player == null)
            return;
            if(player.position.x > transform.position.x){
                transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
            }else{
                transform.localScale = originalScale;
            }
    }

    #endregion
}
