using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHelper : MonoBehaviour
{
    #region Events

    public UnityEvent OnAttackPerformed;
    public UnityEvent OnChargePerformed;

    #endregion

    #region Animation Event Callbacks

    public void TriggerAttack()
    {
        OnAttackPerformed?.Invoke();
    }

    public void TriggerCharge()
    {
        OnChargePerformed?.Invoke();
    }

    #endregion
}
