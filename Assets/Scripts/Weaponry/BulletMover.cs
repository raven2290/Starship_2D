using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.up * speed * Time.deltaTime);
    }
}
