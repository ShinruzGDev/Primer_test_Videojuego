using UnityEngine;

public class Ratatin_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float rotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal"); 
        float VerticalMovement = Input.GetAxis("Vertical"); 

        Vector3 direction = new Vector3(HorizontalMovement, VerticalMovement, 0); 
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
