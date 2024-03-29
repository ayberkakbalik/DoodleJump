using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Pooling : MonoBehaviour
{
    public float minX_platform_spawn_position = -2.1f;
    public float maxX_platform_spawn_position = 1.5f;
    public float minY_platform_spawn_position = 11f;
    public float maxY_platform_spawn_position = 12f;

    private void OnTriggerEnter2D(Collider2D contact)
    {
        float randomX = Random.Range(minX_platform_spawn_position, maxX_platform_spawn_position);
        float randomY = Random.Range(minY_platform_spawn_position, maxY_platform_spawn_position);

        float randomXEnemyAlien = Random.Range(minX_platform_spawn_position, maxX_platform_spawn_position);  // D��man i�in 
        float randomYEnemyAlien = Random.Range(30f, 50f);

        if (contact.tag == "Platform" || contact.tag == "JumpingPlatform")  // Temas edilen objenin tagi Platform veya Jumping Platform ise
        {
            contact.transform.position = new Vector3(randomX, contact.transform.position.y + randomY, contact.transform.position.z);
        }

        if (contact.tag == "EnemyAlien")  // Temas edilen objenin tagi Enemy ise
        {
            contact.transform.position = new Vector3(randomXEnemyAlien, contact.transform.position.y + randomYEnemyAlien, contact.transform.position.z);
        }

        /*if (contact.tag == "JumpingPlatform") // Temas edilen objenin tagi JumpingPlatform ise
        {
             contact.transform.position = new Vector3(randomX, contact.transform.position.y + randomY, contact.transform.position.z);
        }*/
    }

}
