using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelThree : MonoBehaviour
{
    public bool testVar;
    public CinemachineBrain brain;
    public GameObject player;
    public GameObject winPanel3;


    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        winPanel3.SetActive(false);
        Debug.Log("Level 3");
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

            winPanel3.SetActive(true);

            player.GetComponent<PlayerScript>().enabled = false;

        }
    }

    //-----Next Scene Load-------
    public void Lvl3Next()
    {audioManager.StopSFX();
        SceneManager.LoadScene(4);
    }
}
