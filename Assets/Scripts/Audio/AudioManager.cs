using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	[Header("Audio Source")]
	public AudioSource sfxSource;

	public void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void PlaySFX(AudioClip clip)
	{
		if (clip != null)
			sfxSource.PlayOneShot(clip);
	}
}
