using UnityEngine;

public class TextRotater : MonoBehaviour
{
    public GameObject character;
    public GameObject text;
    void Update()
    {
        text.transform.rotation = character.transform.rotation;
    }
}
