using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLScript : MonoBehaviour
{
    public GameObject plyr;
    public float testVar, testVar2;
    public ParticleSystem explosion;
    public CinemachineBrain brain;
    public GameObject drowningCubes;
    public float speed = 0.00000000000000000000000001f;

    float timer;
    float delay = 2f;

    float timer2;
    float delay2 = 0.3f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    // Start is called before the first frame update
    void Start()
    {
        testVar = 1;
        testVar2 = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        Cinemachine.CinemachineVirtualCamera activeCam = (CinemachineVirtualCamera)brain.ActiveVirtualCamera;
        if (brain.ActiveVirtualCamera == null)
        {
            Debug.LogWarning("No active virtual camera.");
            return;
        }

        if (activeCam.name == "StaticCam1" && testVar == 1)
        {
            explosion.Play();
            audioManager.PlaySFX(audioManager.blast);

            testVar++;

        }

        if (activeCam.name == "StaticCam2")
        {
            //drowningCubes.transform.position = new Vector3(-12.6877365f, 0.8f, -4.09860229f);
            if(drowningCubes.transform.position.y >= 1f)
            {
                timer += Time.deltaTime;
                if (timer >= delay)
                {
                    drowningCubes.transform.Translate(Vector3.down * speed * Time.deltaTime);
                    timer = 0f;
                    testVar2 = 3;
                    Debug.Log(" first drowningg");
                }
                

               

            }
        }

        if (testVar2 == 3)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= delay2)
            {
                drowningCubes.transform.Translate(Vector3.down * speed * Time.deltaTime);
                timer2 = 0f;
                Debug.Log("drowningg");

            }

        }

    }

    




    public void DisableControls()
    {
        plyr.GetComponent<PlayerScript>().enabled = false; ;
    }
    public void EnableControls()
    {
        plyr.GetComponent<PlayerScript>().enabled = true; ;
    }

    
}
