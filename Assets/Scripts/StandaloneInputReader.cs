using System;
using UnityEngine;

public class StandaloneInputReader : InputReader
{
    private Vector2 _screenLastClickPoint = Vector2.zero;
    private Vector2 _screenTouchMoveDelta = Vector2.zero;
    private bool _isMouseDown = false;


    public override Vector2 GetScreenTouchPoint()
    {
        return _screenLastClickPoint;
    }

    public override Vector2 GetScreenTouchMoveDelta()
    {
        return _screenTouchMoveDelta;
    }

    public override bool IsTouching()
    {
        return _isMouseDown;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!_isMouseDown) //If new click
            {
                _screenLastClickPoint = Input.mousePosition;
            }

            _isMouseDown = true;
            _screenTouchMoveDelta.x = (Input.mousePosition.x - _screenLastClickPoint.x) / (float) Screen.width;
            _screenTouchMoveDelta.y = (Input.mousePosition.y - _screenLastClickPoint.y) / (float) Screen.height;

            // Debug.Log((Input.mousePosition.x - _screenLastClickPoint.x) + " / " + Screen.width + " = " + _screenTouchMoveDelta.x);
            _screenLastClickPoint = Input.mousePosition;
        }
        else
        {
            _screenTouchMoveDelta = Vector2.zero;
            _isMouseDown = false;
        }
    }
}