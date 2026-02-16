using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public float camera_speed = 8f;
    public float yOffset = 10f;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, camera_speed * Time.deltaTime);
    }
}
