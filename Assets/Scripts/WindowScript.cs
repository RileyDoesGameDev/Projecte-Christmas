using UnityEngine;

public class WindowScript : MonoBehaviour
{
    public GameObject window;
    void OnTriggerEnter(Collider other)
    {
        GameObject bomb = other.gameObject;
        if(bomb.CompareTag("Bomb"))
        {
            window.SetActive(false);
        }
    }
}
