using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TO DO check if collision is a Player !-to na odwrot false to ture itd
       if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        //TO DO Send info to Player

      Inventory inventory = collision.gameObject.GetComponent<Inventory>();
        //TO DO Destroy collectible
        Destroy(gameObject);
    }
}
