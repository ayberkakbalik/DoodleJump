using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.SceneManagement;

public class Character_Movement : MonoBehaviour
{

    public Rigidbody2D doodle;
    public float speed = 10f;  // X axis i�in
    public float movementInput = 0f;

    public float jumpPower = 8f;  
    public float jumpPowerHelicalSpring = 16f;  // Yayl� Platforma dokununca z�plama g�c�
    public float jumpPowerEnemyAlien = 16f;

    Vector2 velocity;
    
    /*public TextMeshProUGUI scoreText; // Skor texti i�in
    int score = 0;                                               //Score text ikinci yap���m
    float floatScore = 0f;*/

    public AudioSource jumpingEffectAudioSource;     //Sound Effects
    public AudioSource jumpingHelicalSpringEffectAudioSource;

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
        movementInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;  // Hareketi h�zland�rmak i�in speed ile �arp�l�r.
        doodle.velocity = new Vector2(movementInput, doodle.velocity.y);

        if (doodle.velocity.x > 0.1f)   // Karakter x axis'te Sa�a gitti�inde
        {
            doodleSpriteRenderer.flipX = false;

        }
        if (doodle.velocity.x < -0.1f)  // Karakter x axis'te Sola gitti�inde
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
        /* if (doodle.velocity.y <= 0.1f)         //�LK �NCE B�YLE YAPMI�TIM
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
                jumpingEffectAudioSource.Play();
                
            }
            if (platform.collider.tag == "JumpingPlatform" || platform.collider.tag == "EnemyAlien")
            {
                velocity = doodle.velocity;
                velocity.y = jumpPowerHelicalSpring;
                doodle.velocity = velocity;
                jumpingHelicalSpringEffectAudioSource.Play();
             
            }
        }

        if (platform.gameObject.tag == "End")  // Yanma
        {
            
            SceneManager.LoadScene(DoodleJumpConstants.LAST_MENU_NAME);
            //SceneManager.LoadScene(DoodleJumpConstants.MAIN_MENU_NAME);  3. YAPTI�IM SON

            //Time.timeScale = 0f;  // Zaman� durdur   ***** BUNU KARAKTER� G�R�NMEZ YAPARAK DE���T�R!!!!
            //SceneManager.LoadScene(0);    2. olarak bunu yapm��t�m
        }

        /*if (platform.gameObject.tag == "Platform")
        {
            score += Random.Range(10, 50);
            scoreText.text = "Score: " + score;   // FOR SCORE TEX    - �LK YAPI�IM


            floatScore = transform.position.y * 10;                    //�K�NC� YAPI�IM         - YEN� OLAN Camera_Follow'da
            score = (int)floatScore;
            scoreText.text = "Score: " + score.ToString();
        }*/
    }

    /*void OnTriggerEnter2D(Collider2D finish)  // Yanma      �lk �nce b�yle denedim ama finish collider� ile object pooling birbirine temas edip oyun duruyordu.
    {
        if (finish.tag == "End")  // E�er finish objesinin tagi End ise
        {
            Time.timeScale = 0f;  // Zaman� durdur
        }
        
    }*/

  



    /*   Rigidbody2D rigidbody = character.collider.GetComponent<Rigidbody2D>();
       if (character.relativeVelocity.y <= 0f) // E�er karakter a�a�� do�ru gidiyorsa
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
