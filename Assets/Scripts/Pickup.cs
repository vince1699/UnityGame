using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            
            if ( gameObject.tag == "Coin"){
                Inventory.instance.AddCoins(1);
                Destroy(gameObject);
            }
            if ( gameObject.tag == "Key"){
                Inventory.instance.AddKeys(1);
                Destroy(gameObject);
            }
        }
    }
}
