using UnityEngine;

public class ParticleSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParticleSystem part = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var part = GetComponent<ParticleSystem>();
        //part.Play();
        //Destroy(gameObject, part.main.duration);
	}
}
