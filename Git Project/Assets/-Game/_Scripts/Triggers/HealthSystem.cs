using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    #region Serialized Fields

    [Header("Health Settings")]
    [SerializeField] public float currentHealth;
    [SerializeField] [HideInInspector] public float maxHealth;
    [SerializeField] [HideInInspector] private bool isDead = false;

    [Header("Events")]
    public UnityEvent<GameObject> OnHitWithReference;
    public UnityEvent<GameObject> OnDeathWithReference;

    #endregion

    #region Private Variables

    private GameObject Cinemachine;
    private CameraEffects cameraEffects;

    #endregion

    #region Initialization

    // Initialize CameraEffects reference
    private void Start()
    {
        Cinemachine = GameObject.FindGameObjectWithTag("Cinemachine");
        cameraEffects = Cinemachine.GetComponent<CameraEffects>();
    }

    // Initialize health with the specified value
    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }
    public void addHealth(){
        currentHealth += 50;
    }

    #endregion

    #region Health Management

    // Reduce health when hit by the specified amount
    public void GetHit(int amount, GameObject sender)
    {
        if (isDead)
            return;

        if (sender.layer == gameObject.layer)
            return;

        currentHealth -= amount;

        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);
            cameraEffects.ShakeCamera();
            PlayRandomHitSound();
        }
        else
        {
            OnDeathWithReference?.Invoke(sender);
            cameraEffects.ShakeCamera();
            PlayRandomDeathSound();
            isDead = true;
        }
    }

    #endregion

    #region Sound Effects

    private void PlayRandomHitSound()
    {
        SoundManager.PlaySound(Random.Range(0, 2) == 0 ? "playerHit" : "enemyHit");
        SoundManager.PlaySound("hurtEnemy");
    }

    private void PlayRandomDeathSound()
    {
        SoundManager.PlaySound(Random.Range(0, 2) == 0 ? "playerHit" : "enemyHit");
        SoundManager.PlaySound("deathEnemy");
    }

    #endregion
}
