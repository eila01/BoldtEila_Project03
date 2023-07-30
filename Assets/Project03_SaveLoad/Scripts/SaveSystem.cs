using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] GameObject _playerPos;
    // asking for health
    [SerializeField] private Health _health;

    public void SaveData()
    {
        float max = _health.MaxHealth;
        
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

        // player known stats

    }
    public void LoadData()
    {
        // load position
        transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));

        // load rotation
        transform.rotation = Quaternion.Euler(PlayerPrefs.GetFloat("PlayerRotationX"), PlayerPrefs.GetFloat("PlayerRotationY"), PlayerPrefs.GetFloat("PlayerRotationZ"));

        // load health
        PlayerPrefs.GetInt("PlayerCurrentHealth");
    }
}
