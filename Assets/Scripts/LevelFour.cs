using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFour : MonoBehaviour
{
    public bool testVar;
    public CinemachineBrain brain;
    public GameObject player;
    public GameObject winPanel4;


    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        winPanel4.SetActive(false);
        Debug.Log("Level 4");

    }

    // Update is called once per frame
    void Update()
    {
        Cinemachine.CinemachineVirtualCamera activeCam = (CinemachineVirtualCamera)brain.ActiveVirtualCamera;

        if (brain.ActiveVirtualCamera == null)
        {
            Debug.LogWarning("no active virtual cams.");
            return;
        }
        if (activeCam.name == "VirtualCam2" && testVar == true)
        {
            player.GetComponent<PlayerScript>().enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            audioManager.PlaySFX(audioManager.win);

            winPanel4.SetActive(true);
            player.GetComponent<PlayerScript>().enabled = false;

        }
    }
    //-----Next Scene Load-------
    public void Lvl4Next()
    {
        
            audioManager.StopSFX();

            SceneManager.LoadScene(5);
    }
}
