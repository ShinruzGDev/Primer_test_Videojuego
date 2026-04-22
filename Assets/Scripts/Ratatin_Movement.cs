using TMPro;
using UnityEngine;


public class Ratatin_Movement : MonoBehaviour
{
    public float speed = 5f; //velocidad del jugador
    public float rotation_speed = 70f; //velocidad de rotación
    public bool life = true; //la vida de ratatín pq realmente se muere del toque
    public int queso = 0;
    public int queso2 = 0;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScoreScpecial;
    public TextMeshProUGUI notificationText;
    Rigidbody2D rb; //Recolecta info del rigidbody del player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>(); //Esta línea está aqui por que no quería procesar bien las rotaciones del personaje :p
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.forward * -HorizontalMovement * rotation_speed * Time.deltaTime);
        transform.Translate(Vector3.right * VerticalMovement * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Trampa"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Scene");
            ShowNotification("Te ha matado la trampa!");
        }

        if(other.CompareTag("Agujero") && queso2 == 5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Scene");
            ShowNotification("Has Ganado Ratatín!");
        }

        if (other.CompareTag("Agujero") && queso2 != 5)
        {
            ShowNotification("Te faltan más Quesos Premium");
        }

        if (other.CompareTag("Queso"))
        {
            queso = queso + 1;
            UpdateTextScore();
            speed = speed + 0.5f;
            Destroy(other.gameObject);
            ShowNotification("Yummy!");
        }

        if(other.CompareTag("Queso_Dorado"))
        {
            queso = queso + 5;
            queso2 = queso2 + 1;
            UpdateTextScore();
            UpdateTextScoreScpecial();
            Destroy(other.gameObject);
            ShowNotification("Super Yummy!");
        }

        if(other.CompareTag("Queso_Azul"))
        {
            queso = queso - 1;
            speed = speed - 1;
            UpdateTextScore();
            Destroy(other.gameObject);
            ShowNotification("Eugh");
        }

        if(other.CompareTag("Queso_Blanco"))
        {
            queso = queso - 5;
            UpdateTextScore();
            Destroy(other.gameObject);
            ShowNotification("Super Eugh");
        }
    }
    void UpdateTextScore()
    {
        textScore.text = "Queso: " + queso;
    }
    void UpdateTextScoreScpecial()
    {
        textScoreScpecial.text = "Queso Premium: " + queso2 +"/5";
    }
    void ShowNotification(string message)
    {
        notificationText.text = message;
    }
}
