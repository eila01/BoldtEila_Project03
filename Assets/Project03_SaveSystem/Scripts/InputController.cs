using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InputController : MonoBehaviour
{
    [SerializeField] GameObject _playerPos;

    [SerializeField] private Health _objectWithHealth;
    [SerializeField] private SaveSystem _saveSystem;

    public  HealthHUD _healthHUD;

    // Show UI Test
    [SerializeField] public TextMeshProUGUI _uiSaveText;
    [SerializeField] public TextMeshProUGUI _uiLoadText;

    void Start()
    {
        _uiSaveText.gameObject.SetActive(false);
        _uiLoadText.gameObject.SetActive(false);
    }

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
            _uiSaveText.gameObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
        // load game
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Load Key is Pressed");

            _saveSystem.LoadData();
            _healthHUD.ScaleHealthBar();
            _uiLoadText.gameObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    public void SaveTest()
    {
        Debug.Log("Save Key is Pressed");
        _saveSystem.SaveData();
        _uiSaveText.gameObject.SetActive(true);
        StartCoroutine("WaitForSec");
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3);
        
        _uiSaveText.gameObject.SetActive(false);
        _uiLoadText.gameObject.SetActive(false);
    }
}
