using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private Transform doodle;

    //Buradan sonrasý denemedir:
     public TextMeshProUGUI scoreText; // Skor texti için
     int score =0;
     float floatScore = 0f;     // Because camera is float

     private void Update()
     {
         floatScore = transform.position.y * 10;
         score = (int)floatScore;     // We want to turn float score to integer score
         scoreText.text = "Score: " + score.ToString();
     }
     //20. SATIRA KADAR YANÝ 4. SATIR VE 9-20 ARASI DENEMEDÝR

    public void LateUpdate()
    {
        if(doodle.position.y > transform.position.y) // Eðer Doodle kameradan daha yüksekteyse
        {
            Vector3 newPosition = new Vector3(transform.position.x, doodle.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
 
}
