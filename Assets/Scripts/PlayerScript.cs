using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public GameObject player;

    public static int failedSceneNum;


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
        //---- Function Calls ------

        MyPlayerScript();

        if (player.transform.position.y < 0f)
        {
        Scene currentScene = SceneManager.GetActiveScene();

            failedSceneNum = currentScene.buildIndex;

            SceneManager.LoadScene(8);
            audioManager.PlaySFX(audioManager.fail);
        }

    }

    public void MyPlayerScript()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        // float Jumpp = Input.GetAxis("Jump");

        transform.Translate( 0, 0, VerticalInput * speed * Time.deltaTime);

        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, MouseX * speed * 25 * Time.deltaTime, 0);

    }

    
}
