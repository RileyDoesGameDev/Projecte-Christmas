using UnityEngine;

public class WindowScript : MonoBehaviour
{
    public GameObject window;
    private void OnTriggerEnter(Collider other)
    {
        GameObject bomb = other.gameObject;
        if(bomb.name == "pig")
        {
            window.SetActive(false);
            bomb.SetActive(false);
        }
    }
}
