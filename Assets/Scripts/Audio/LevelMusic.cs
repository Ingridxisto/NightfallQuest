using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    public AudioClip musicThisLevel;

    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(musicThisLevel);
        }
    }
}
