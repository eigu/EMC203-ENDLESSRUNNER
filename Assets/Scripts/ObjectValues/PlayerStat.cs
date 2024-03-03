using System;
using System.Collections;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class PlayerStat : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int CurrentHealth { get; private set; }

    [SerializeField] private float _damageInterval;
    [SerializeField] private float _recoveryInterval;

    private bool m_hasTakenDamage = false;
    private bool m_hasRecovered = false;

    private Coroutine m_recoverCoroutine;

    public Action<int> OnHealthChange;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    private void ChangeHP(int amount)
    {
        CurrentHealth += amount;
        if (OnHealthChange != null) OnHealthChange(CurrentHealth);
    }

    private void FixedUpdate()
    {
        if (CurrentHealth < MaxHealth) Recover(1);
    }

    public void Damage(int amount)
    {
        if (m_hasTakenDamage) return;
        if (m_recoverCoroutine != null) ResetRecoverTimer();
        StartCoroutine(DamageLogic(amount));
    }

    public void Recover(int amount)
    {
        if (m_hasRecovered) return;
        m_recoverCoroutine = StartCoroutine(RecoverLogic(amount));
    }

    private IEnumerator DamageLogic(int amount)
    {
        m_hasTakenDamage = true;
        ChangeHP(amount);
        yield return new WaitForSeconds(.25f);
        m_hasTakenDamage = false;
    }
    private IEnumerator RecoverLogic(int amount)
    {
        m_hasRecovered = true;
        yield return new WaitForSeconds(_recoveryInterval);
        ChangeHP(amount);
        m_hasRecovered = false;
    }

    private void ResetRecoverTimer()
    {
        m_hasRecovered = false;
        StopCoroutine(m_recoverCoroutine);
    }
}