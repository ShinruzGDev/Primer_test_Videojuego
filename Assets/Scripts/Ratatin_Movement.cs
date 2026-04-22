using UnityEngine;

public class Ratatin_Movement : MonoBehaviour
{
    public float speed = 5f; //velocidad del jugador
    public float rotation_speed = 100f; //velocidad de rotación
    Rigidbody2D rb; //Recolecta info del rigidbody del player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Esta línea está aqui por que no quería procesar bien las rotaciones del personaje :p
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.forward * -HorizontalMovement * rotation_speed * Time.deltaTime);
        transform.Translate(Vector3.right * VerticalMovement * speed * Time.deltaTime);
    }
}
