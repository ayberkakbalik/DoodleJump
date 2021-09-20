using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManagement : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D playerCollider)
    {
        if(playerCollider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(DoodleJumpConstants.LAST_MENU_NAME);
        }
    }

}
