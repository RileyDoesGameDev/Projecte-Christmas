using UnityEngine;
namespace ItemHoldNameSpace{
    public class ItemHold : MonoBehaviour{
        public static ItemHold Instance { get; private set; }
        public GameObject player, bomb;
        private GameObject healdItem;
        public static int bombItemNumber;
        public Rigidbody rigidbody;
        private void Awake(){Instance = this;}
        public void Hold(GameObject item){   
            if(healdItem is not null) healdItem.transform.position = player.transform.position;
            healdItem = item;
            healdItem.transform.position += Vector3.down * 10f;
        }
        public static void HoldStatic(GameObject item){
            if(Instance != null){
                Instance.Hold(item);
                BombCraftStatic();      
            }
        }
        public static void BombCraftStatic(){
            Debug.Log(bombItemNumber + "");
            if(Instance.healdItem.CompareTag("BombItem1")){
                bombItemNumber = 1;
                Instance.healdItem.SetActive(false);
            } 
            else if(Instance.healdItem.CompareTag("BombItem2") && bombItemNumber == 1){
                bombItemNumber = 2;
                Instance.healdItem.SetActive(false);
            }
            else if(Instance.healdItem.CompareTag("BombItem3") && bombItemNumber == 2) Instance.MoveBomb();
            //else bombItemNumber = 0;
        }
        public void MoveBomb(){

            Debug.Log("BOmb made");
            Instance.healdItem.SetActive(false);
            bomb.transform.SetPositionAndRotation(player.transform.position, player.transform.rotation);
            bombItemNumber = 0;
            rigidbody.isKinematic = false;
            rigidbody.linearVelocity = bomb.transform.forward * 0;
            Instance.Hold(bomb);
        }
        public static GameObject GetHealdItemStatc(){return Instance.GetHealdItem();}
        public GameObject GetHealdItem(){return healdItem;}
    }
}