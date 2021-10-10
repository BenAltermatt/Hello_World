using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent
{
    private float[] mouseScreenPos;
    private float[] mouseRealPos;
    private int buttonPressed;

    public MouseEvent(Camera cam)
    {

        this.mouseScreenPos = new float[2];
        this.mouseRealPos = new float[2];

        // figure out the position of the mouse on the screen
        Vector3 tempPos = Input.mousePosition;
        this.mouseScreenPos[0] = tempPos.x;
        this.mouseScreenPos[1] = tempPos.y;

        // figure out the position of the mouse within the world
        tempPos = cam.ScreenToWorldPoint(tempPos);
        this.mouseScreenPos[0] = tempPos.x;
        this.mouseScreenPos[1] = tempPos.y;

        
    }
}
