using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   public int coinsCount;
   public Text coinsText;
   public int keysCount;
   public Text keysText;

   public static Inventory instance;

   private void Awake(){
       if(instance != null)
       {
           Debug.LogWarning("Il y a plus d'une instance Inventory");
           return;
       }
       instance = this;
   }

   public int GetKeys(){
        return keysCount;
   }

   public void RemoveKey(int remov){
        keysCount -= remov;
        keysText.text = keysCount.ToString();
   }

   public void AddCoins(int count){
        coinsCount += count;
        coinsText.text = coinsCount.ToString();
   }
   public void AddKeys(int count2){
        keysCount += count2;
        keysText.text = keysCount.ToString();
   }
}
