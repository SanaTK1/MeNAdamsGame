using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public float camera_speed = 8f;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + 10, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, camera_speed * Time.deltaTime);
    }
}
