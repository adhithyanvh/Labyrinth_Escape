
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip background;
    public AudioClip buttonClick;
    public AudioClip ocean;
    public AudioClip fail;
    public AudioClip win;
    public AudioClip blast;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
       musicSource.clip = background;
        musicSource.Play();

    }

    public void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name != "Home")
        {
            musicSource.Stop();
        }
    }

   
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void StopSFX()
    {
        sfxSource.Stop();
    }
    public void PlayBgm(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
}
