using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ladder : MonoBehaviour
{
    public bool isInRange;
    private Text interactUI;
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E)){
            playerMovement.isClimbing = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        isInRange = true;
        interactUI.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision){
        isInRange = false;
        playerMovement.isClimbing = false;
        interactUI.enabled = false;
    }
}
