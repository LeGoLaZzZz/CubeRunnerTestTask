using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotator : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public Vector3 rotationVector = new Vector3(0, 0, 0);

    [SerializeField] private bool allowRotation;

    private Transform _transform;


    public void StartRotation()
    {
        allowRotation = true;
    }

    public void StopRotation()
    {
        allowRotation = false;
    }

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        StartRotation();
    }

    private void Update()
    {
        if (allowRotation)
        {
            RotateTick(Time.deltaTime);
        }
    }

    private void RotateTick(float deltaTime)
    {
        _transform.Rotate(rotationVector, rotationSpeed * deltaTime);
    }
}