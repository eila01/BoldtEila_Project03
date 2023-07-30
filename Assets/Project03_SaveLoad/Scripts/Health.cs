using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent Damaged;
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    
    public void TakeDamage(int damageAmount)
    {
        Debug.Log(damageAmount);

        damageAmount = System.Math.Abs(damageAmount);

        _currentHealth -= damageAmount;

        Damaged.Invoke();

        if(_currentHealth <= 0)
        {
            Kill();
        }
    }
    public void Kill()
    {
        Debug.Log("Player is Dead");
    }
}
