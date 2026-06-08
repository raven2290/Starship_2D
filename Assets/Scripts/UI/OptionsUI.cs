using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
	[Header("UI Elements")]
	public Slider volumeSlider;
	public TMP_Dropdown graphicsDropdown;
	public TMP_Dropdown resolutionDropdown;
	public Toggle fullScreenToggle;

	Resolution[] resolutions;

	// Pending (unapplied) settings
	float pendingVolume;
	int pendingQuality;
	int pendingResolutionIndex;
	bool pendingFullscreen;

	void Start()
	{
		// -------------------------
		// LOAD SAVED SETTINGS
		// -------------------------
		pendingVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
		pendingQuality = PlayerPrefs.GetInt("GraphicsQuality", 2);
		pendingResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
		pendingFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

		// -------------------------
		// SET UI ELEMENTS
		// -------------------------
		volumeSlider.value = pendingVolume;
		graphicsDropdown.value = pendingQuality;
		fullScreenToggle.isOn = pendingFullscreen;

		// -------------------------
		// RESOLUTION SETUP
		// -------------------------
		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();

		var options = new System.Collections.Generic.List<string>();
		int currentResIndex = 0;

		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width &&
				resolutions[i].height == Screen.currentResolution.height)
			{
				currentResIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = pendingResolutionIndex;
		resolutionDropdown.RefreshShownValue();

		// -------------------------
		// LISTENERS (update pending values only)
		// -------------------------
		volumeSlider.onValueChanged.AddListener(v => pendingVolume = v);
		graphicsDropdown.onValueChanged.AddListener(q => pendingQuality = q);
		resolutionDropdown.onValueChanged.AddListener(r => pendingResolutionIndex = r);
		fullScreenToggle.onValueChanged.AddListener(f => pendingFullscreen = f);
	}

	// -------------------------
	// APPLY BUTTON
	// -------------------------
	public void ApplySettings()
	{
		// Volume
		AudioListener.volume = pendingVolume;
		PlayerPrefs.SetFloat("MasterVolume", pendingVolume);

		// Graphics Quality
		QualitySettings.SetQualityLevel(pendingQuality);
		PlayerPrefs.SetInt("GraphicsQuality", pendingQuality);

		// Fullscreen
		Screen.fullScreen = pendingFullscreen;
		PlayerPrefs.SetInt("Fullscreen", pendingFullscreen ? 1 : 0);

		// Resolution
		Resolution res = resolutions[pendingResolutionIndex];
		Screen.SetResolution(res.width, res.height, pendingFullscreen);
		PlayerPrefs.SetInt("ResolutionIndex", pendingResolutionIndex);

		PlayerPrefs.Save();
	}

	// -------------------------
	// CANCEL BUTTON
	// -------------------------
	public void CancelSettings()
	{
		// Reload saved settings
		pendingVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
		pendingQuality = PlayerPrefs.GetInt("GraphicsQuality", 2);
		pendingResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
		pendingFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

		// Update UI
		volumeSlider.value = pendingVolume;
		graphicsDropdown.value = pendingQuality;
		resolutionDropdown.value = pendingResolutionIndex;
		fullScreenToggle.isOn = pendingFullscreen;
	}
}
