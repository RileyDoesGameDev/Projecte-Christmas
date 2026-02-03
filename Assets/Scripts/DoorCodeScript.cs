using UnityEngine;
using UnityEngine.InputSystem;

public class DoorCodeScript : MonoBehaviour
{
    private bool isInBox = false;
    private int currentStep = 0;

    public RoomTriggers[] doorTriggers;

    private static readonly Key[] codeSequence =
    {
        Key.UpArrow, Key.UpArrow, Key.DownArrow, Key.DownArrow,
        Key.LeftArrow, Key.RightArrow, Key.LeftArrow, Key.RightArrow,
        Key.A, Key.B, Key.Escape
    };

    void Update()
    {
        if (!isInBox) return;

        var keyboard = Keyboard.current;
        if (keyboard.anyKey.wasPressedThisFrame)
        {
            if (keyboard[codeSequence[currentStep]].wasPressedThisFrame)
            {
                currentStep++;
                if (currentStep >= codeSequence.Length)
                {
                    UnlockDoors();
                    currentStep = 0;
                }
            }
            else
            {
                currentStep = 0;
            }
        }
    }

    private void UnlockDoors()
    {
        Debug.Log("Code entered!");
        foreach (var trigger in doorTriggers)
        {
            trigger.Unlocked = true;
        }
    }

    private void OnTriggerEnter(Collider other) => isInBox = true;
    private void OnTriggerExit(Collider other) => isInBox = false;
}