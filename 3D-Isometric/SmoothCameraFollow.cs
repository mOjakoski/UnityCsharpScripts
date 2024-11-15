using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SmoothCameraFollow : MonoBehaviour
{
    private Vector3 _offset;

    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;

    private Vector3 _currentVelcoity = Vector3.zero;

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelcoity, smoothTime);    
    }

}
