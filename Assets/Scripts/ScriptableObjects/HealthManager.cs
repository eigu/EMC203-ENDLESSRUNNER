using System;
using UnityEngine;

[CreateAssetMenu]
public class HealthManager : ScriptableObject
{
  [SerializeField]
  private int _maxHealth;
  public int CurrentHealth { get; private set; }

  public event Action<int> OnHealthChange;

  private void OnEnable()
  {
    CurrentHealth = _maxHealth;
  }

  public void Decrease(int amount)
  {
    CurrentHealth -= amount;
    OnHealthChange?.Invoke(CurrentHealth);
  }

  public void Increase(int amount)
  {
    CurrentHealth += amount;
    OnHealthChange?.Invoke(CurrentHealth);
  }
}
