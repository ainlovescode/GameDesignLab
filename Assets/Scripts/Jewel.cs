using UnityEngine;
using System.Collections;
[System.Serializable]
public class Jewel : Consumable
{
   public int amount{get ; private set;}
   public GameObject[] jewels;
   private int index = 0;

   public Jewel(items type,
             int amount,
             float damage = 0,
             float health = 0) : base (type, damage, health)
   {
       this.amount = amount;
       jewels = new GameObject[amount];  

        // Subscribe to hit event
        ItemManager.onHit += hit;
    
   }
   public void add(GameObject jewel){
       if (index < amount){
           //set its index
           // jewel.GetComponent<BasicObjectScript>().index = index;
           // jewel.GetComponent<BasicObjectScript>().type = type;
           jewels[index] = jewel;
           index ++;
       }
      
   }

    
   public void hit(items type, int index){
       if (type == this.type){
           jewels[index].SetActive(false); //make the jewel inactive
           amount --;
        }
   }



   
}
