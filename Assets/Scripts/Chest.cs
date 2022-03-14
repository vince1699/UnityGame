using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Chest : MonoBehaviour
{
    private Text interactUI;
    public bool isInRange;
    public Animator animator ;
    // Start is called before the first frame update
    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update(){
        if(isInRange && Input.GetKeyDown(KeyCode.E)){
            if(Inventory.instance.GetKeys()>=1){
                
                animator.SetTrigger("Open");
                OpenChest();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        isInRange = true;
        interactUI.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision){
        isInRange = false;
        interactUI.enabled = false;
    }
    void OpenChest(){
        Inventory.instance.AddCoins(10);
        Inventory.instance.RemoveKey(1);
    }
}
