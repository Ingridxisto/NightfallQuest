using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

   [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip musicMenu;
    public AudioClip musicFase1;
    public AudioClip musicFase2;
    public AudioClip musicFase3;
    public AudioClip musicFase4;
    public AudioClip musicFase5;

    [Header("SFX")]
    public AudioClip runSFX;
    public AudioClip jumpSFX;
    public AudioClip attackSFX;
    public AudioClip deathSFX;
    public AudioClip collectSFX;

    [Header("Portal")]
    public AudioClip portalSFX;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ===== SFX =====
    public void PlayCollect()
    {
        sfxSource.PlayOneShot(collectSFX);
    }

    public void PlayRun()
    {
        sfxSource.PlayOneShot(runSFX);
    }

    public void PlayJump()
    {
        sfxSource.PlayOneShot(jumpSFX);
    }

    public void PlayAttack()
    {
        sfxSource.PlayOneShot(attackSFX);
    }

    public void PlayDeath()
    {
        sfxSource.PlayOneShot(deathSFX);
    }

    public void PlayPortal()
    {
        sfxSource.PlayOneShot(portalSFX);
    }

    // ===== MUSIC =====
    public void PlayMusic(AudioClip music)
    {
        if (musicSource.clip == music) return;

        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }
}

