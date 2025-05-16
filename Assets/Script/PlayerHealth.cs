using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour , IDamagable
{
    [SerializeField] int _health = 100;
    bool _isDead = false;
    
    [SerializeField] Animator _animator;
    
    //useless now
    //public int Health { get { return _health; } private set { _health = value; } } 
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    private void Update()
    {
        if (_health <= 0)
        {
            _isDead = true;
            _animator.SetTrigger("Die");
        }
            
    }
}
