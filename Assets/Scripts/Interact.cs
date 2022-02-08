using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public enum interactType {Ladder, Door};


   public interactType type;
    PlayerMovement mov;



   private void Start() {
        mov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
   }


private void OnTriggerExit(Collider other) 
{
   if(gameObject.gameObject.GetComponent<BoxCollider>() != null){
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            StartCoroutine(Timer());

            mov.Reset();

   }


}



   public void Interacted()
   {

       switch (type){
            case interactType.Ladder:
            
             
             mov.Climb();
    

            
                break;

       }
      
   }
    IEnumerator Timer()
    {
      yield return new WaitForSeconds(3f);
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
       yield return null;
    }
   
}
