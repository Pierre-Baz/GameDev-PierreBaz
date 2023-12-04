using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyManager : MonoBehaviour
{
    #region Events

    public UnityEvent YesEnergy;
    public UnityEvent NoEnergy;

    #endregion

    #region Serialized Fields

    [Header("Kinetic Energy Settings")]
    [SerializeField] public float currentKineticEnergy;
    [SerializeField] public float maxKineticEnergy = 100.0f;
    [SerializeField] private float KineticEnergyDecayRate = 0.5f;
    [SerializeField] private float KineticEnergyAttack = 4f;
    [SerializeField] private float KineticEnergyCharge = 6f;
    [SerializeField] private float KineticEnergyGain = 50f;
    [SerializeField] private float HealthEnergyGain = 50f;

    #endregion

    #region Private Variables

    private Vector3 lastPosition;
    private bool hasEnergyDepleted = false;
    private HealthSystem healthSystem;

    #endregion

    #region Unity Callbacks

    private void Start()
    {
        currentKineticEnergy = maxKineticEnergy;
        lastPosition = transform.position;
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Update()
    {
        float distanceMoved = (transform.position - lastPosition).magnitude;
        currentKineticEnergy -= distanceMoved * KineticEnergyDecayRate;
        currentKineticEnergy = Mathf.Max(0, currentKineticEnergy);
        lastPosition = transform.position;

        if (currentKineticEnergy <= 0 && !hasEnergyDepleted)
        {
            hasEnergyDepleted = true;
            NoEnergy?.Invoke();
        }
        else if (currentKineticEnergy > 0)
        {
            hasEnergyDepleted = false;
            YesEnergy?.Invoke();
        }
    }
    public void LootSystemSorter(string lootName){
        
        if(lootName == "Energy"){
            energyGain();
        }
        if(lootName == "Healing"){
            healthGain();
        }
    }

    public void AttackEnergy()
    {
        currentKineticEnergy -= KineticEnergyAttack;
    }

    public void ChargeEnergy()
    {
        currentKineticEnergy -= KineticEnergyCharge;
    }

    public void energyGain()
    {
        currentKineticEnergy += KineticEnergyGain;
    }
    public void healthGain(){
        healthSystem.currentHealth += HealthEnergyGain;
    }

    #endregion
}
