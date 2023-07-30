using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Events;

public class SaveSystem : MonoBehaviour
{
   // public UnityEvent Save;

    public GameObject _playerPos;
    // asking for player health
    [SerializeField]  private Health _health;

   // public HealthHUD _healthHUD;

    void Start()
    {
        LoadData();
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

    }
}
