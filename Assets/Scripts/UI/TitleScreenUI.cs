using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class TitleScreenUI : MonoBehaviour
{
    [Header("Title Color Cycle")]
    public TMP_Text titleText;
    public Color[] cycleColors;
    public float cycleSpeed;
    public float letterOffset;

    [Header("Typewriter Effect")]
    public TMP_Text keyPress;
    public float typeSpeed;
    public float delayBeforeRepeat;
    public bool loopTypewriter = true;

    string fullPressText;

    void Start()
    {
        // cache the full text for the typewriter
        fullPressText = keyPress.text;

        //start typewriter animation
        StartCoroutine(TypewriterRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        RunTitleColorCycle();

        if (Input.anyKeyDown)
        {
            GameManager.instance.ActivateMainMenuStateObject();
        }
    }

    //-------------------------------
    // title color cycling
    //-------------------------------
    void RunTitleColorCycle()
    {
        if (titleText == null || cycleColors.Length < 2)
        return;

        titleText.ForceMeshUpdate();
        var mesh = titleText.mesh;
        var colors32 = mesh.colors32;

        for (int i = 0; i < titleText.text.Length; i++)
        {
			int charIndex = titleText.textInfo.characterInfo[i].vertexIndex;
			if (charIndex < 0) continue;

			float t = Mathf.Sin(Time.time * cycleSpeed + i * letterOffset) * 0.5f + 0.5f;
			Color c = Color.Lerp(cycleColors[0], cycleColors[1], t);

			colors32[charIndex + 0] = c;
			colors32[charIndex + 1] = c;
			colors32[charIndex + 2] = c;
			colors32[charIndex + 3] = c;
		}

        mesh.colors32 = colors32;
        titleText.canvasRenderer.SetMesh(mesh);
    }
	//-------------------------------
	// Typewriter Effect
	//-------------------------------
	IEnumerator TypewriterRoutine()
	{
		while (true)
		{
			keyPress.text = "";

			for (int i = 0; i < fullPressText.Length; i++)
			{
				keyPress.text = fullPressText.Substring(0, i + 1);
				yield return new WaitForSeconds(typeSpeed);
			}

			yield return new WaitForSeconds(delayBeforeRepeat);

			if (!loopTypewriter)
				break;
		}
	}
}
