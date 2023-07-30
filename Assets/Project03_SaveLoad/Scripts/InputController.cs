using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] GameObject _playerPos;

    [SerializeField] private Health _objectWithHealth;
    [SerializeField] private SaveSystem _saveSystem;

    public  HealthHUD _healthHUD;

    private void Update()
    {
        // apply damage on input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _objectWithHealth.TakeDamage(15);
        }
        // save game
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Save Key is Pressed");
            _saveSystem.SaveData();
        }
        // load game
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Load Key is Pressed");

            _saveSystem.LoadData();
            _healthHUD.ScaleHealthBar();
        }
    }


     
}
