using UnityEngine;

public class DoorCodeScript : MonoBehaviour
{
    public GameObject textBox;
    public GameObject textPrompt;
    private void OnTriggerEnter(Collider other) {
        textBox.SetActive(true);
        textPrompt.SetActive(true);
    }
        
    private void OnTriggerExit(Collider other) {
        textBox.SetActive(false);
        textPrompt.SetActive(false);
    }
}
