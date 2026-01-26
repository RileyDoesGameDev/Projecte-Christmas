using UnityEngine;
using UnityEngine.InputSystem;
using ItemHoldNameSpace;
namespace itemNameSpace{
    public class ItemPickUp : MonoBehaviour
    {
        public GameObject item;
        public bool canPickUp;
       // public PlayerInventory inventory;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {   
            if (canPickUp)
            {
                if (Keyboard.current.eKey.isPressed)
                {
                    //ItemHold itemHolder = new ItemHold();
                    
                }
            }


                
        }
        // public void MoveUp()
        // {
        //     item.transform.position += Vector3.up * 10f;
        // }
        private void OnTriggerEnter(Collider other) {

           
            canPickUp = true;
        }
        private void OnTriggerExit(Collider other) {
            canPickUp = false;
        }
    }
}
