using System;
using System.Collections.Generic;
using Unity.Multiplayer.PlayMode;
using UnityEngine;
using UnityEngine.InputSystem;

public class Server : MonoBehaviour
{
    

   
    public Material material;
    public GameObject currentPlayer = null;

    public List<GameObject> DoorTriggers = new List<GameObject>();

    void Start()
    {
        material.color = Color.red;
    }

    
    void Update()
    {



        if (Keyboard.current.eKey.wasPressedThisFrame && currentPlayer != null)
        {
            foreach (GameObject obj in DoorTriggers)
            {
                obj.GetComponent<RoomTriggers>().Unlocked = true;
            }

            material.color = Color.green;
        }



       

    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentPlayer = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentPlayer = null;
        }
    }


   


}
