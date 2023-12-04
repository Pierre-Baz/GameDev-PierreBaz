using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    #region Variables

    private Slider slider;
    private HealthSystem healthSystem;
    private GameObject player;
    public TextMeshProUGUI TMP;

    #endregion

    #region Initialization

    public void Start()
    {

    }

    private void InitializeReferences()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            healthSystem = player.GetComponent<HealthSystem>();
            slider = GetComponentInChildren<Slider>();
            slider.maxValue = healthSystem.maxHealth;
        }
        else
        {
            return;
        }
    }

    #endregion

    #region Update Health Bar

    public void Update()
    {
        UpdateHealthValue();
        if(healthSystem != null){
            UpdateTextValue();
        }
    }

    private void UpdateHealthValue()
    {
        if (player != null)
        {
            slider.value = healthSystem.currentHealth;
        }
    }
    private void UpdateTextValue(){
        TMP.text = Mathf.RoundToInt(healthSystem.currentHealth) + "/" + Mathf.RoundToInt(healthSystem.maxHealth);
    }

    #endregion
}
