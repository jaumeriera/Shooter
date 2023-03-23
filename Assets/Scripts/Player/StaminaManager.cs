using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    [SerializeField]
    float totalStamina;
    [SerializeField]
    float jumpCost;
    [SerializeField]
    float runCost;
    [SerializeField]
    float timeToStartRegeneration;
    [SerializeField]
    float staminaRegeneration;
    [SerializeField]
    FloatVariable currentStamina;
    [SerializeField]
    FloatVariable runCostVariable;
    [SerializeField]
    FloatVariable jumpCostVariable;

    [SerializeField]
    GameEvent UpdateStaminaUI;

    private Coroutine regenerationCoroutine;

    void Start()
    {
        currentStamina.Value = totalStamina;
        jumpCostVariable.Value = jumpCost;
        runCostVariable.Value = runCost;
    }

    public void ApplyJump() {
        currentStamina.Value -= jumpCostVariable.Value;
        UpdateStaminaUI.Raise();
    }

    public void ApplyRun() {
        currentStamina.Value -= runCostVariable.Value * Time.deltaTime;
        UpdateStaminaUI.Raise();
    }

    public void RegenerateStaminaBar() {
        regenerationCoroutine = StartCoroutine(DoRenenerateStamina());
    }

    private IEnumerator DoRenenerateStamina() {
        yield return new WaitForSeconds(timeToStartRegeneration);
        while (currentStamina.Value < totalStamina) {
            currentStamina.Value += staminaRegeneration * Time.deltaTime;
            yield return null;
        }
    }

    public void StopRegeneratingStamina() {
        if (regenerationCoroutine != null) {
            StopCoroutine(regenerationCoroutine);
        }
    }

    
}
