using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthHUD : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Transform _healthBar;
    [SerializeField] private Image _healthFillImage;
    [SerializeField] private Vector3 _offset = new Vector3(0, 1, 0);

    private void Awake()
    {
        transform.SetParent(null);
    }
    private void Update()
    {
        
    }

    public void ScaleHealthBar()
    {
        
    }
}
