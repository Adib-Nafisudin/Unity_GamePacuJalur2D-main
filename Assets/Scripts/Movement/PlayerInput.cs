using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static bool inputRight;
    public static bool inputLeft;
    public static void inputRightDown() => inputRight = true;
    public static void inputRightUp() => inputRight = false;
    public static void inputLeftDown() => inputLeft = true;
    public static void inputLeftUp() => inputLeft = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inputLeftDown();
        } 
        if (Input.GetKeyUp(KeyCode.Q))
        {
            inputLeftUp(); 
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            inputRightDown();
        } 
        if (Input.GetKeyUp(KeyCode.E))
        {
            inputRightUp(); 
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            inputRightDown();
            inputLeftDown();
        } 
        if (Input.GetKeyUp(KeyCode.W))
        {
            inputRightUp(); 
            inputLeftUp(); 
        }
    } 
}
