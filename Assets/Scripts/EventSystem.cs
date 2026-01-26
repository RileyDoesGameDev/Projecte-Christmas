using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour
{
    

    //SceneManager sceneManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlay()
    {
        Debug.Log("Start Play");
        SceneManager.LoadScene("SampleScene");
    }

    

}
