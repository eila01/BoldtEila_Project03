using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    [SerializeField] private Health _objectWithHealth;
    
    private void Update()
    {
        // apply damage on input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _objectWithHealth.TakeDamage(15);
        }
        // save game
        if (Input.GetKeyDown(KeyCode.S))
        {

        }
        // load game
        if (Input.GetKeyDown(KeyCode.L))
        {

        }
    }

    public void SaveGame()
    {
       
    }
}
