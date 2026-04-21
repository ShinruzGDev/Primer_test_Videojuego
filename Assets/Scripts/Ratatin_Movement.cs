using UnityEngine;

public class Ratatin_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float rotation_speed = 200f;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal");
        Debug.Log(HorizontalMovement);
        float VerticalMovement = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.forward * -HorizontalMovement * rotation_speed * Time.deltaTime);
        transform.Translate(Vector3.right * VerticalMovement * speed * Time.deltaTime);
    }
}
