using UnityEngine;
using itemNameSpace;
namespace ItemHoldNameSpace
{
    public class ItemHold : MonoBehaviour
    {
        public static ItemHold Instance { get; private set; }
        public GameObject player;
        private GameObject healdItem;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public void Hold(GameObject item)
        {   
            if(healdItem is not null)
            {
                healdItem.transform.position += Vector3.up * 10f;
            }
            healdItem = item;
            healdItem.transform.position += Vector3.down * 10f;
        }
        
        // Optional: static access wrapper
        public static void HoldStatic(GameObject item)
        {
            if (Instance != null){
                Instance.Hold(item);
                //item.transform.position += Vector3.down * 10f;
            }   
            else{
                Instance.Hold(item);
                //item.transform.position += Vector3.down * 10f;
            }
        }
    }

}
    
