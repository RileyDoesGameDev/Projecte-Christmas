using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

   
    public GameObject Player;
    public Phone phone;
    public GameObject PhoneCaller;
    public GameObject Santa;
    public Transform SantaTubeLocation;
    public GameObject Computer;
    public GameObject glassBreaking;
    public GameObject Pig;
    public GameObject PizzaOven;

    public List<GameObject> DoorTriggers = new List<GameObject>();
    public List<GameObject> DoorTriggersUnlock = new List<GameObject>();
    
    void Start()
    {
        if(phone != null)
        {
            phone.OnPhoneAwnsered += OnPhoneTriggerd;
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (Santa.GetComponent<Interactable>().Triggered)
        {
            OnSyringeUsed();
            Santa.GetComponent<Interactable>().Triggered = false;

        }

        if (Computer.GetComponent<Interactable>().Triggered)
        {
            OnInputPassword();
            Computer.GetComponent<Interactable>().Triggered = false;
        }

        if (PizzaOven.GetComponent<Interactable>().Triggered)
        {
            OnPieMade();
            PizzaOven.GetComponent <Interactable>().Triggered = false;
        }
        
    }


    void OnPhoneTriggerd()
    {
        PhoneCaller.SetActive(true);


        Player.GetComponent<PlayerCharacter>().enabled = true;
    }


    void OnSyringeUsed()
    {

        Santa.transform.position = SantaTubeLocation.position;
        Santa.transform.rotation = SantaTubeLocation.rotation;
        Santa.GetComponent<Animation>().enabled = true;

    }

    void OnInputPassword()
    {

        glassBreaking.SetActive(true);
        Santa.SetActive(false);
        foreach(GameObject obj in DoorTriggers)
        {
            obj.GetComponent<RoomTriggers>().Unlocked = false;
        }

        foreach(GameObject obj in DoorTriggersUnlock)
        {
            obj.GetComponent<RoomTriggers>().Unlocked = true;
        }

    }


    void OnPieMade()
    {
        Pig.SetActive(true);
    }

    internal void StartLevel(int v)
    {
        throw new NotImplementedException();
    }
}
