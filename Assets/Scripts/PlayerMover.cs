using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    /// <summary>
    ///  Proportion of movement and swipe.
    ///  If swipeInputProportion == 1 then on swipe 100% of screen - player moves 100% of space
    ///  If swipeInputProportion == 0.5 then  on swipe 100% of screen - player moves 50% of space
    /// </summary>
    public float swipeInputProportion = 1;

    [SerializeField] private PlayerMoveZone playerMoveZone;

    private Transform _transform;
    private float _currentPoint;

    private void Awake()
    {
        _transform = transform;
        _currentPoint = 0;
    }

    private void Update()
    {
        _transform.LookAt(playerMoveZone.groundPoint);
        if (InputReader.Instance.IsTouching())
        {
            MoveTick(Time.deltaTime);
        }
    }

    private void MoveTick(float timeDelta)
    {
        var moveProportion = swipeInputProportion * InputReader.Instance.GetScreenTouchMoveDelta().x;
        _currentPoint += moveProportion;
        moveProportion = Mathf.Clamp(_currentPoint, 0f, 1f);

        _transform.position = playerMoveZone.GetMovePoint(moveProportion);
    }
}