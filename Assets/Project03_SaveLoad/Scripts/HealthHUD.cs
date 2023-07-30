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
        if(_health == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = _health.transform.position + _offset;
    }

    public void ScaleHealthBar()
    {
        float max = _health.MaxHealth;
        float current = _health.CurrentHealth;

        float newXScale = (1 / max) * current;
          newXScale = Mathf.Clamp(newXScale, 0, 1);

        _healthFillImage.transform.localScale = new Vector3(newXScale, 1, 1);

    }
}
