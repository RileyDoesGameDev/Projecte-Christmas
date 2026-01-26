using UnityEngine;
using itemNameSpace;
namespace ItemHoldNameSpace
{
    public class ItemHold : MonoBehaviour
    {
        public static ItemHold Instance { get; private set; }
        public GameObject player;
        private GameObject healdItem;
        public GameObject bomb;
        public static int bombItemNumber = 0;
        private void Awake()
        {
            // if (Instance != null && Instance != this)
            // {
            //     Destroy(gameObject);
            //     return;
            // }
            Instance = this;
        }

        public void Hold(GameObject item)
        {   
            if(healdItem is not null){
                //doing the bomb stuff
                // if(Instance.healdItem.CompareTag("BombItem1")) bombItemNumber = 1; 
                // else if(Instance.healdItem.CompareTag("BombItem2") && bombItemNumber == 1) bombItemNumber = 2;
                // else if(Instance.healdItem.CompareTag("BombItem3") && bombItemNumber == 2) bomb.transform.position = player.transform.position;
                // else{
                    healdItem.transform.position += Vector3.up * 10f;
                    bombItemNumber = 0;
                //}
                
            }
            healdItem = item;
            healdItem.transform.position += Vector3.down * 10f;
        }
        
        // Optional: static access wrapper
        public static void HoldStatic(GameObject item)
        {
            if (Instance != null){
                if(Instance.healdItem.CompareTag("BombItem1")) bombItemNumber = 1; 
                else if(Instance.healdItem.CompareTag("BombItem2") && bombItemNumber == 1) bombItemNumber = 2;
                else if(Instance.healdItem.CompareTag("BombItem3") && bombItemNumber == 2) Instance.bomb.transform.position = Instance.player.transform.position;
                
                Instance.Hold(item);            
            }
        }
        public static GameObject GetHealdItemStatc()
        {
            return Instance.GetHealdItem();
        }
        public GameObject GetHealdItem()
        {
            return healdItem;
        }
    }

}
    
