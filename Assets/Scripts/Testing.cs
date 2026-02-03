using NUnit.Framework;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;




[Serializable]

public class AudioSystemTests
{
    [Test]
    public void Test_Audio_No_Overlap()
    {
        // Arrange
        GameObject audioManagerObj = new GameObject("AudioManager");
        AudioManager audioManager = audioManagerObj.AddComponent<AudioManager>();

        // Act
        audioManager.PlayBackgroundMusic("theme");
        audioManager.PlayBackgroundMusic("battle");

        int activeAudioSources = 0;
        AudioSource[] sources = audioManagerObj.GetComponents<AudioSource>();

        foreach (AudioSource source in sources)
        {
            if (source.isPlaying)
                activeAudioSources++;
        }

        // Assert
        Assert.AreEqual(1, activeAudioSources,
            $"Expected 1 active audio source, but found {activeAudioSources}");
        
      
        
    }
}



public class ObjectiveUITests
{
    [Test]
    public void Test_Objective_UI_Exists_And_Displays()
    {
        // Arrange
        GameObject canvasObj = new GameObject("Canvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();

        GameObject uiManagerObj = new GameObject("UIManager");
        UIManager uiManager = uiManagerObj.AddComponent<UIManager>();

        // Act
        uiManager.SetObjective("Collect 10 coins");
        Text objectiveText = uiManager.GetObjectiveText();
        bool isVisible = objectiveText != null && objectiveText.gameObject.activeInHierarchy;

        // Assert
        Assert.IsNotNull(objectiveText, "Objective UI Text component not found");
        Assert.IsTrue(isVisible, "Objective UI is not visible");
        Assert.AreEqual("Collect 10 coins", objectiveText.text,
            "Objective text does not match expected value");

    }
}



public class BackgroundAudioTests
{
    [UnityTest]
    public IEnumerator Test_Background_Music_Plays_On_Level_Start()
    {
        // Arrange
        GameObject gameManagerObj = new GameObject("GameManager");
        GameManager gameManager = gameManagerObj.AddComponent<GameManager>();

        GameObject audioManagerObj = new GameObject("AudioManager");
        AudioManager audioManager = audioManagerObj.AddComponent<AudioManager>();

        // Act
        gameManager.StartLevel(1);

        // Wait for initialization
        yield return new WaitForSeconds(0.5f);

        bool isMusicPlaying = audioManager.IsBackgroundMusicPlaying();
        float volume = audioManager.GetBackgroundMusicVolume();

        // Assert
        Assert.IsTrue(isMusicPlaying, "Background music is not playing during gameplay");
        Assert.Greater(volume, 0f, $"Background music volume is {volume}, expected > 0");

       
    }
}




















public class Testing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
