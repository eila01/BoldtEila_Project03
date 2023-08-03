using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent()]
[RequireComponent(typeof(Collider))]
public class SaveCheckpoint : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private bool _oneShot = true;
    [Header("Filters")]
    [SerializeField]
    private GameObject _specificTriggerObject = null;
    [SerializeField]
    private LayerMask _layerToDetect = -1;
    public UnityEvent OnEnterTrigger;

    private Collider _collider;
    private bool _alreadyEntered = false;

    [Header("Gizmos Settings")]
    [SerializeField]
    private bool _displayGizmos = false;
    [SerializeField]
    private Color _gizmoColor = Color.green;
    [SerializeField]
    private bool _showOnWhileSelected = true;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (_oneShot && _alreadyEntered)
        {
            return;
        }
        
        if (_specificTriggerObject != null && other.gameObject != _specificTriggerObject)
        {
            return;
        }
        
        if (_layerToDetect != (_layerToDetect | (1 << other.gameObject.layer)))
        {
            return;
        }

        Debug.Log("Enter");
        OnEnterTrigger.Invoke();
        _alreadyEntered = true;



    }

    private void OnDrawGizmos()
    {
        if (_displayGizmos == false)
        {
            return;
        }
        if (_showOnWhileSelected == true)
        {
            return;
        }
        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }
        Gizmos.color = _gizmoColor;
        Gizmos.DrawCube(transform.position, _collider.bounds.size);
    }
    private void OnDrawGizmosSelected()
    {
        if (_displayGizmos == false)
        {
            return;
        }
        if (_showOnWhileSelected == false)
        {
            return;
        }
        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }
        Gizmos.color = _gizmoColor;
        Gizmos.DrawCube(transform.position, _collider.bounds.size);
    }

    public void ResetTrigger()
    {
        _alreadyEntered = false;
    }
}
