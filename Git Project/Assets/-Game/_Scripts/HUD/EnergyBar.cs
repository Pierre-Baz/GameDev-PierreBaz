using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBar : MonoBehaviour
{
    #region Variables

    private Slider slider;
    private EnergyManager energyManager;
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
            energyManager = player.GetComponent<EnergyManager>();
            slider = GetComponentInChildren<Slider>();
        }
        else
        {
            return;
        }
    }

    #endregion

    #region Update Energy Bar

    public void Update()
    {
        UpdateEnergyValue();
        if(energyManager != null){
            UpdateTextValue();
        }
    }

    private void UpdateEnergyValue()
    {
        if (player != null && energyManager != null)
        {
            slider.value = energyManager.currentKineticEnergy;
        }
    }
    private void UpdateTextValue(){
        TMP.text = Mathf.RoundToInt(energyManager.currentKineticEnergy) + "/" + Mathf.RoundToInt(energyManager.maxKineticEnergy);
    }

    #endregion
}
