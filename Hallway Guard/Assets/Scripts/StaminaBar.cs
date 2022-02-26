using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    private int maxStamina = 100;

    private float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    public static StaminaBar instance;

    private Coroutine regen;

    public MovementTest playermove;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentStamina = maxStamina;

        staminaBar.maxValue = maxStamina;

        staminaBar.value = maxStamina;
    }

    void Update()
    {
        if(currentStamina > 40)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                UseStamina(0.40f);
            }

            playermove.speed = 5f;
            playermove.sprintSpeed = 10f;
        }
        else if (currentStamina <= 40)
        {
            playermove.isSprinting = false;
            staminaBar.value = currentStamina;
            playermove.speed = 3f;
            playermove.sprintSpeed = 5f;
        }


    }

    public void UseStamina(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
    }
}

