using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Image currentHealthbar;
    public Text ratioText;

    private float currentPointFuel;
    public float maxHealth = 200;
    public float damageFuel = 1;

    void Start()
    {
        Debug.LogError("START FuelBar");
        currentPointFuel = maxHealth;
        InvokeRepeating("DamageFuel", 1, 1);
    }

    void DamageFuel()
    {
        Debug.LogError("DAMAGE FuelBar");
        currentPointFuel -= damageFuel;
        if (currentPointFuel > 0)
            UpdateFuelBar();
        else
            Debug.LogError("Dead!");
    }

    void UpdateFuelBar()
    {
        Debug.LogError("UPDATE FuelBar");
        float ratio = currentPointFuel / maxHealth;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (Mathf.Floor(ratio * 100)).ToString() + '%';
    }

    public void HealFuel()
    {
        Debug.LogError("HEAL FuelBar");
        currentPointFuel += 15;
        if (currentPointFuel > maxHealth)
            currentPointFuel = maxHealth;

        UpdateFuelBar();
    }

}
