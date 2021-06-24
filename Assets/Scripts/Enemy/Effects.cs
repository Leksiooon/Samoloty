using UnityEngine;

public class Effects : MonoBehaviour
{
    public GameObject explosion;
    ParticleSystem explosionPS;

    public AudioClip audioClip;
    AudioSource audioSource;

    public void Start()
    {
        explosionPS = explosion.GetComponent<ParticleSystem>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioClip != null)
        {
            audioSource.playOnAwake = false;
            audioSource.loop = false;
            audioSource.clip = audioClip;
        }
    }

    public bool isPlaying { get => explosionPS.isPlaying; }

    public void Play()
    {
        Start();

        if (explosionPS != null && !explosionPS.isPlaying)
            explosionPS.Play();
        if (audioSource != null && !audioSource.isPlaying)
            audioSource.Play();
    }
}
