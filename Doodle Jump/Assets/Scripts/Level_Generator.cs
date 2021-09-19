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
        Vector3 objectPosition = new Vector3 ();  // Objenin klonlanaca�� pozisyonu tutuyoruz

        for (int i = 0; i < platformAmount; i++)  //Platform say�s� yerine y eksenini dene
        {
            objectPosition.x = Random.Range(min_x, max_x);
            objectPosition.y = Random.Range(min_y, max_y);
            Instantiate (platformObject, objectPosition, Quaternion.identity); //hangi obje, objenin pozisyonu, objenin a��lar� ama 2d oldu�u i�in platformun a��s�n� 0'd�r
        }
        
    }

   // Buraya yeni tip platformlar (�rn: git gide k�salan) ekleyip belirli bir maxy'den sonra o platformlar� generate etmesini sa�lamay� dene
}
