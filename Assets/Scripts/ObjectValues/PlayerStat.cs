using System;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    [field: SerializeField]
    public int MaxHealth { get; private set; }

    [field:SerializeField]
    public int CurrentHealth { get; private set; }

    [SerializeField]
    private float _recoveryInterval;
    private float m_recoveryTimer;

    public Action<int> OnHealthChange;


    private void Start()
    {
        CurrentHealth = MaxHealth;
        m_recoveryTimer = _recoveryInterval;
    }

    private void Update()
    {
        m_recoveryTimer -= Time.deltaTime;

        if (m_recoveryTimer <= 0)
        {
            IncreaseHP(1);
            m_recoveryTimer = _recoveryInterval;
        }
    }

    public void DecreaseHP(int amount)
    {
        CurrentHealth -= amount;
        if (OnHealthChange != null) OnHealthChange(CurrentHealth);
    }

    public void IncreaseHP(int amount)
    {
        CurrentHealth += amount;
        if (OnHealthChange != null) OnHealthChange(CurrentHealth);
    }
}
