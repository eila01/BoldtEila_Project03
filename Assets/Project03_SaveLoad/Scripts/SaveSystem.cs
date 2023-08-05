using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


public class SaveSystem : MonoBehaviour
{
   // public UnityEvent Save;

    public GameObject _playerPos;

    
    // asking for player health
    [SerializeField]  private Health _health;

    // Player Stats
    [SerializeField] public TextMeshProUGUI _uiHealthText;
    [SerializeField] public TextMeshProUGUI _uiPowerText;
    [SerializeField] public TextMeshProUGUI _uiDefenseText;

    public int _healthNum = 100;
    public int _powerNum = 2;
    public int _defenseNum = 5;

    void Start()
    {
        LoadData();
        _uiHealthText.text = "Health: " + _healthNum;
        _uiPowerText.text = "Power: " + _powerNum;
        _uiDefenseText.text = "Defense: " + _defenseNum;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _healthNum -= 5;
            _uiHealthText.text = "Health: " + _healthNum;
            if(_healthNum <= 0)
            {
                _healthNum = 100;
                LoadData();
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            _powerNum += 1;
            _uiPowerText.text = "Power: " + _powerNum;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            _defenseNum += 1;
            _uiDefenseText.text = "Defense: " + _defenseNum;
        }
    }

    public void SaveData()
    {
        float max = _health.CurrentHealth;
        
        // player position
        PlayerPrefs.SetFloat("PlayerX", _playerPos.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", _playerPos.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", _playerPos.transform.position.z);

        // Player Rotation
        PlayerPrefs.SetFloat("PlayerRotationX", _playerPos.transform.rotation.x);
        PlayerPrefs.SetFloat("PlayerRotationY", _playerPos.transform.rotation.y);
        PlayerPrefs.SetFloat("PlayerRotationZ", _playerPos.transform.rotation.z);

        // player current health
        PlayerPrefs.SetFloat("PlayerCurrentHealth", max);
        Debug.Log("Current Health" + max);

        // player other stats...
        PlayerPrefs.SetInt("PlayerHealthNum", _healthNum);
        PlayerPrefs.SetInt("PlayerPowerNum", _powerNum);
        PlayerPrefs.SetInt("PlayerDefenseNum", _defenseNum);

        PlayerPrefs.Save();
       // Save.Invoke();
    }
    public void LoadData()
    {
        // load position
        _playerPos.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));

        // load rotation
        _playerPos.transform.rotation = Quaternion.Euler(PlayerPrefs.GetFloat("PlayerRotationX"), PlayerPrefs.GetFloat("PlayerRotationY"), PlayerPrefs.GetFloat("PlayerRotationZ"));

        // load health
        PlayerPrefs.GetInt("PlayerCurrentHealth");
        //_healthHUD.ScaleHealthBar();
        PlayerPrefs.GetInt("PlayerHealthNum");
        PlayerPrefs.GetInt("PlayerPowerNum");
        PlayerPrefs.GetInt("PlayerDefenseNum");
    }
}
