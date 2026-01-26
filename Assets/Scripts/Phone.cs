using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Phone : MonoBehaviour
{

    public GameObject currentPlayer = null;


    public event Action OnPhoneAwnsered;
    
    void Start()
    {
      
    }

    
    void Update()
    {

        if (Keyboard.current.eKey.isPressed && currentPlayer != null)
        {
            UsePhone();
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


    private void UsePhone()
    {
        OnPhoneAwnsered?.Invoke();
        Destroy(gameObject);
    }


   


}
