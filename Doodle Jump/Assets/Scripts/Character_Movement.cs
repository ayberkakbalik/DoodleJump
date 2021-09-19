using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Character_Movement : MonoBehaviour
{

    public Rigidbody2D doodle;
    public float speed = 10f;  // X axis için
    public float movementInput = 0f;

    public float jumpPower = 8f;  
    public float jumpPowerHelicalSpring = 16f;  // Yaylý Platforma dokununca zýplama gücü
    Vector2 velocity;

    public TextMeshProUGUI scoreText; // Skor texti için
    int score;

  

    Vector2 screenTopRightCornerWorldPosition;
    Vector2 screenTopLeftCornerWorldPosition;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private SpriteRenderer doodleSpriteRenderer;

    void Update()
    {
      
        ChangeCharacterFacingDirectionDependingOnVelocity();
        KeepCharacterWithinBoundries();

    }

    private void ChangeCharacterFacingDirectionDependingOnVelocity()
    {
        movementInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;  // Hareketi hýzlandýrmak için speed ile çarpýlýr.
        doodle.velocity = new Vector2(movementInput, doodle.velocity.y);

        if (doodle.velocity.x > 0.1f)   // Karakter x axis'te Saða gittiðinde
        {
            doodleSpriteRenderer.flipX = false;

        }
        if (doodle.velocity.x < -0.1f)  // Karakter x axis'te Sola gittiðinde
        {
            doodleSpriteRenderer.flipX = true;
        }
    }

    private void KeepCharacterWithinBoundries()
    {
        screenTopRightCornerWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        screenTopLeftCornerWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, mainCamera.transform.position.z));

        
        if (transform.position.x > screenTopRightCornerWorldPosition.x + doodleSpriteRenderer.size.x * transform.localScale.x)
        {
            transform.position = new Vector3(screenTopLeftCornerWorldPosition.x, transform.position.y, -1);
        }
        if (transform.position.x < screenTopLeftCornerWorldPosition.x - doodleSpriteRenderer.size.x * transform.localScale.x)
        {
            transform.position = new Vector3(screenTopRightCornerWorldPosition.x, transform.position.y, -1);
        }
    }


    void OnCollisionEnter2D(Collision2D platform)
    {
        /* if (doodle.velocity.y <= 0.1f)
         {
             velocity = doodle.velocity;
             velocity.y = jumpPower;
             doodle.velocity = velocity;

         }*/
        if (doodle.velocity.y <= 0.1f)
        {
            if(platform.collider.tag == "Platform")
            {
                velocity = doodle.velocity;
                velocity.y = jumpPower;
                doodle.velocity = velocity;
            }
            if (platform.collider.tag == "JumpingPlatform")
            {
                velocity = doodle.velocity;
                velocity.y = jumpPowerHelicalSpring;
                doodle.velocity = velocity;
            }

        }

        if (platform.gameObject.tag == "End")  // Yanma
        {
            SceneManager.LoadScene(0);
            //Time.timeScale = 0f;  // Zamaný durdur   ***** BUNU KARAKTERÝ GÖRÜNMEZ YAPARAK DEÐÝÞTÝR!!!!
        }

        if (platform.gameObject.tag == "Platform")
        {
            score += Random.Range(10, 50);
            scoreText.text = "Score: " + score;   // For score text
        }
    }

    /*void OnTriggerEnter2D(Collider2D finish)  // Yanma      Ýlk önce böyle denedim ama finish colliderý ile object pooling birbirine temas edip oyun duruyordu.
    {
        if (finish.tag == "End")  // Eðer finish objesinin tagi End ise
        {
            Time.timeScale = 0f;  // Zamaný durdur
        }
        
    }*/

  



    /*   Rigidbody2D rigidbody = character.collider.GetComponent<Rigidbody2D>();
       if (character.relativeVelocity.y <= 0f) // Eðer karakter aþaðý doðru gidiyorsa
       {
           if (rigidbody != null)
           {
               velocity = rigidbody.velocity;
               velocity.y = jumpPower;
               rigidbody.velocity = velocity;
           }
       }*/

    /*private void FixedUpdate()
    {
        Vector2 velocity = doodle.velocity;
        velocity.x = movementInput;
        doodle.velocity = velocity;
    }*/
}
