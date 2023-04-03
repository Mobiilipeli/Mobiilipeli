using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TouchHandler
{
    public static Vector2  handleTouch() 
    {
        if (Input.touchCount==0) 
        {
            return Vector2.zero;
        }
        Touch touch = Input.GetTouch(0);
        bool isTouching = touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved;
        return touch.deltaPosition/30;
        
    }
}
