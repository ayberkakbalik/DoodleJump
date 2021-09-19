using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Generator : MonoBehaviour
{

    public GameObject platformObject;
    public int platformAmount;
    public float min_x, max_x;
    public float min_y, max_y;
    
    
    void Start()
    {
        Vector3 objectPosition = new Vector3 ();  // Objenin klonlanacaðý pozisyonu tutuyoruz

        for (int i = 0; i < platformAmount; i++)  //Platform sayýsý yerine y eksenini dene
        {
            objectPosition.x = Random.Range(min_x, max_x);
            objectPosition.y = Random.Range(min_y, max_y);
            Instantiate (platformObject, objectPosition, Quaternion.identity); //hangi obje, objenin pozisyonu, objenin açýlarý ama 2d olduðu için platformun açýsýný 0'dýr
        }
        
    }

   // Buraya yeni tip platformlar (örn: git gide kýsalan) ekleyip belirli bir maxy'den sonra o platformlarý generate etmesini saðlamayý dene
}
