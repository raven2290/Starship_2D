using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
	[Header("UI Elements")]
	public Slider volumeSlider;
	public TMP_Dropdown graphicsDropdown;

	void Start()
	{
		// Initialize with saved settings or defaults
		volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
		graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 2);

		volumeSlider.onValueChanged.AddListener(SetVolume);
		graphicsDropdown.onValueChanged.AddListener(SetGraphicsQuality);
	}

	public void SetVolume(float value)
	{
		AudioListener.volume = value;
		PlayerPrefs.SetFloat("MasterVolume", value);
	}

	public void SetGraphicsQuality(int index)
	{
		QualitySettings.SetQualityLevel(index);
		PlayerPrefs.SetInt("GraphicsQuality", index);
	}
}
