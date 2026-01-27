using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class DoorCodeScript : MonoBehaviour
{
    private bool inbox = false, keyPressed = false;
    private int step = 0;
    public GameObject doorTrigger1, doorTrigger2, doorTrigger3, doorTrigger4, doorTrigger5, doorTrigger6;
    void Update()
    {
        if (inbox)
        {
            if(Keyboard.current.anyKey.wasReleasedThisFrame) keyPressed = false;
            if(Keyboard.current.upArrowKey.isPressed && step == 0){ step = 1; keyPressed = true;}
            else if(Keyboard.current.upArrowKey.isPressed && step == 1){ step = 2; keyPressed = true;}
            else if(!keyPressed && Keyboard.current.downArrowKey.isPressed && step == 2){ step = 3; keyPressed = true;}
            else if(!keyPressed && Keyboard.current.downArrowKey.isPressed && step == 3){ step = 4; keyPressed = true;}
            else if(!keyPressed && Keyboard.current.leftArrowKey.isPressed && step == 4){ step = 5; keyPressed = true;}
            else if(!keyPressed && Keyboard.current.rightArrowKey.isPressed && step == 5){ step = 6; keyPressed = true;}
            else if(!keyPressed && Keyboard.current.leftArrowKey.isPressed && step == 6){ step = 7; keyPressed = true;}
            else if(!keyPressed && Keyboard.current.rightArrowKey.isPressed && step == 7){ step = 8; keyPressed = true;}
            else if(!keyPressed && Keyboard.current.aKey.isPressed && step == 8){ step = 9; keyPressed = true;}
            else if(!keyPressed && Keyboard.current.bKey.isPressed && step == 9){ step = 10; keyPressed = true;}
            else if(!keyPressed && Keyboard.current.escapeKey.isPressed && step == 10){ step = 11; keyPressed = true;}
            else if(step == 11) codeEntered();
            else if (Keyboard.current.anyKey.wasPressedThisFrame) step = 0;
        }
    }
    private void codeEntered()
    {
        Debug.Log("code entered");
        doorTrigger1.GetComponent<RoomTriggers>().Unlocked = true;
        doorTrigger2.GetComponent<RoomTriggers>().Unlocked = true;
        doorTrigger3.GetComponent<RoomTriggers>().Unlocked = true;
        doorTrigger4.GetComponent<RoomTriggers>().Unlocked = true;
        doorTrigger5.GetComponent<RoomTriggers>().Unlocked = true;
        doorTrigger6.GetComponent<RoomTriggers>().Unlocked = true;
        step = 0;
    }

    private void OnTriggerEnter(Collider other) {
        inbox = true;

    }
        
    private void OnTriggerExit(Collider other) {
        inbox = false;
    }
}
