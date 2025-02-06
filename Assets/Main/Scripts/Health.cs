using StarterAssets;
using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Health : MonoBehaviour
{
    [Header("Health stats")]
    [SerializeField] private int _maxHealth = 100;

    [SerializeField] private ThirdPersonController _thirdPersonController;
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private Trap _trap;

    private int _currentHealth;


    public event Action<float> HealthChanged;

    private void Awake()
    {
        _trap.GotDamage += ChangeHealth;
    }

    private void OnDisable()
    {
        _trap.GotDamage -= ChangeHealth;
    }

    void Start()
    {
        _currentHealth = _maxHealth; 
    }

    private void ChangeHealth(int value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _maxHealth);
        
        if (_currentHealth <= 0)
        {
            Death();
        }
        else
        {
            float _currentHealthAsPercantage = (float)_currentHealth / _maxHealth;
            HealthChanged?.Invoke(_currentHealthAsPercantage);
        }
    }

    public void Death()
    {
        _thirdPersonController.enabled = false;
        _characterController.enabled = false;
        transform.position = new Vector3(0, 0, -4);
        ChangeHealth(_maxHealth);
        _thirdPersonController.enabled = true;
        _characterController.enabled = true;
    }
}
