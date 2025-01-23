using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScene : MonoBehaviour
{

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yes()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(PlayerScript.failedSceneNum);
        audioManager.StopSFX();

    }

    public void No()
    {
        audioManager.StopSFX();
        SceneManager.LoadScene(0);
    }
}
