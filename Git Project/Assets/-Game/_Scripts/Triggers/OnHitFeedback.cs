using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class OnHitFeedback : MonoBehaviour
{
    #region Serialized Fields

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Animator anim;

    [Header("Feedback Settings")]
    [SerializeField] private float strength;
    [SerializeField] private float delay;

    #endregion
    #region Events

    [Header("Events")]
    public UnityEvent OnBegin;
    public UnityEvent OnDone;

    #endregion

    #region Private Variables

    private Color originalColor;

    #endregion

    #region Initialization

    private void Start()
    {
        originalColor = spriteRenderer.color;
        anim = GetComponent<Animator>();
    }

    #endregion

    #region Feedback Methods

    // Play feedback effect when hit
    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        spriteRenderer.color = Color.red;

        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb2d.AddForce(direction * strength, ForceMode2D.Impulse);

        StartCoroutine(Reset());
    }

    // Play feedback effect when dead
    public void PlayDeath(GameObject sender)
    {
        if (GetComponent<LootBag>() != null)
        {
            GetComponent<LootBag>().InstantiateLoot(transform.position);
        }
        StartCoroutine(Death());
    }

    #endregion

    #region Coroutine Methods

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    // Reset the feedback effect
    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.3f);
        rb2d.velocity = Vector3.zero;
        spriteRenderer.color = originalColor;
        OnDone?.Invoke();
    }

    #endregion
}
