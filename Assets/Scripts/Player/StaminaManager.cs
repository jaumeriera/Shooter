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
    BoolVariable canJump;
    [SerializeField]
    BoolVariable canRun;

    [SerializeField]
    GameEvent UpdateStaminaUI;

    private Coroutine regenerationCoroutine;

    void Start()
    {
        currentStamina.Value = totalStamina;
        jumpCostVariable.Value = jumpCost;
        runCostVariable.Value = runCost;
        canJump.Value = true;
        canRun.Value = true;
    }

    public void ApplyJump() {
        currentStamina.Value -= jumpCostVariable.Value;
        UpdateStaminaUI.Raise();
        canJump.Value = currentStamina.Value > jumpCostVariable.Value;
    }

    public void ApplyRun() {
        currentStamina.Value -= runCostVariable.Value * Time.deltaTime;
        UpdateStaminaUI.Raise();
        canRun.Value = currentStamina.Value > runCostVariable.Value * Time.deltaTime;
    }

    public void RegenerateStaminaBar() {
        if (regenerationCoroutine == null) {
            regenerationCoroutine = StartCoroutine(DoRenenerateStamina());
        }
    }

    private IEnumerator DoRenenerateStamina() {
        yield return new WaitForSeconds(timeToStartRegeneration);
        while (currentStamina.Value < totalStamina) {
            currentStamina.Value += staminaRegeneration * Time.deltaTime;
            UpdateStaminaUI.Raise();
            canRun.Value = currentStamina.Value > runCostVariable.Value * Time.deltaTime;
            canJump.Value = currentStamina.Value > jumpCostVariable.Value;
            yield return null;
        }
        regenerationCoroutine = null;
    }

    public void StopRegeneratingStamina() {
        if (regenerationCoroutine != null) {
            StopCoroutine(regenerationCoroutine);
            regenerationCoroutine = null;
        }
    }

    
}
