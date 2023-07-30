using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = .25f;
    [SerializeField] float _turnSpeed = 1f;

    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        TurnPlayer();
    }

    public void MovePlayer()
    {
        float moveAmountThisFrame = Input.GetAxis("Vertical") * _moveSpeed;

        Vector3 moveOffSet = transform.forward * moveAmountThisFrame;

        _rb.MovePosition(_rb.position + moveOffSet);
    }

    public void TurnPlayer()
    {
        float turnAmountThisFrame = Input.GetAxis("Horizontal") * _turnSpeed;

        Quaternion deltaRotation = Quaternion.Euler(0, turnAmountThisFrame, 0);

        _rb.MoveRotation(_rb.rotation * deltaRotation);
    }

    
}
