using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Movement Settings

    [Header("Movement Settings")]
    [SerializeField] public float moveSpeed = 8f;
    [SerializeField] private ParticleSystem dust;
    [SerializeField] public SpriteRenderer spriteRenderer;


    #endregion

    #region Dash Settings

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashLength = 0.15f;
    [SerializeField] private float dashCooldown = 0.5f;

    #endregion

    #region Private Variables

    public Animator animator;
    private WandParent wandParent;
    private Vector2 pointerInput;

    public float activeMoveSpeed;
    private float dashCooldownCounter;
    private float dashCounter;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference movement;
    [SerializeField] private InputActionReference attack;
    [SerializeField] private InputActionReference charge;
    [SerializeField] private InputActionReference dash;
    [SerializeField] private InputActionReference pointerPosition;

    #endregion

    #region Initialization

    private void Start()
    {
        animator = GetComponent<Animator>();
        wandParent = GetComponentInChildren<WandParent>();
        activeMoveSpeed = moveSpeed;
    }

    #endregion

    #region Update

    private void Update()
    {
        HandleMovement();
        HandleAttack();
        HandleCharge();
        HandleDash();
        HandleSprite();
        UpdateAnimator();
    }

    #endregion

    #region Movement

    private void HandleMovement()
    {
        Vector2 direction = movement.action.ReadValue<Vector2>();
        Vector3 newPosition = transform.position + new Vector3(direction.x, direction.y, 0f) * activeMoveSpeed * Time.deltaTime;
        transform.position = newPosition;
        
        if(direction.magnitude == 0){
            animator.SetBool("Speed", false);
        }else{
            animator.SetBool("Speed", true);
        }

        UpdateDustParticles(direction.magnitude);
    }

    private void UpdateDustParticles(float directionMagnitude)
    {
        if (directionMagnitude > 0 && directionMagnitude != dashSpeed)
        {
            if (!dust.isPlaying)
                dust.Play();
        }
        else
        {
            if (dust.isPlaying)
                dust.Stop();
        }
    }

    #endregion

    #region Attack

    private void HandleAttack()
    {
        if (attack.action.IsPressed())
        {
            wandParent.Attack();
        }
    }

    #endregion

    #region Charge

    private void HandleCharge()
    {
        if (charge.action.IsPressed())
        {
            wandParent.Charge();
        }
    }

    #endregion

    #region Dash

    private void HandleDash()
    {
        if (dash.action.IsPressed() && dashCounter <= 0 && dashCooldownCounter <= 0)
        {
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCooldownCounter = dashCooldown;
            }
        }

        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.deltaTime;
        }
    }

    #endregion

    #region Sprite

    private void HandleSprite(){
        Vector2 direction = movement.action.ReadValue<Vector2>();
        if(direction.x > 0){
            spriteRenderer.flipX = true;
        }
        if(direction.x < 0){
            spriteRenderer.flipX = false;
        }
    }

    #endregion

    #region Animation

    private void UpdateAnimator()
    {
        pointerInput = GetPointerInput();
        wandParent.Pointerposition = pointerInput;
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePosition = pointerPosition.action.ReadValue<Vector2>();
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    #endregion
}
