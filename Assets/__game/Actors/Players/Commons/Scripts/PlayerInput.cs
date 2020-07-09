using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string inputPostfix;
    public float AxisMoveX { get; private set; }
    public float AxisMoveY { get; private set; }
    public bool Punch { get; private set; }
    
    // Update is called once per frame
    void Update()
    {
        AxisMoveX = Input.GetAxisRaw("Horizontal_"+ inputPostfix);
        AxisMoveY = Input.GetAxisRaw("Vertical_" + inputPostfix);
        Punch = Input.GetButtonDown("Fire_" + inputPostfix);
    }

    
}
