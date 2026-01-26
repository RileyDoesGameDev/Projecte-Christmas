using UnityEngine;
using ItemHoldNameSpace;
using UnityEngine.InputSystem;
public class BombScript : MonoBehaviour
{
    public bool isHeld;
    public GameObject bomb;
    public GameObject player;
    public Rigidbody rigidbody;
    public ItemHold itemHold;
    void Update(){
        if(ItemHold.GetHealdItemStatc() != null && ItemHold.GetHealdItemStatc().CompareTag("Bomb")) isHeld = true;
        //else isHeld = false;
        if(Keyboard.current.qKey.isPressed && isHeld)
        {
            GameObject item = ItemHold.GetHealdItemStatc();
            item.transform.SetPositionAndRotation(player.transform.position, player.transform.rotation);
            rigidbody.linearVelocity = bomb.transform.forward * 10;
        }
    }
}
