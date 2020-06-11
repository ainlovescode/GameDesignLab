using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // System.Serializable is so that the editor field appears at 
// Unity during runtime and you can change the values conveniently for debugging or testing
public class Consumable:MonoBehaviour
{   
    public items type{get; private set;}
   public float damage{ get; private set;}
   public float health{ get; private set;}

   public enum items{
       GREENJEWEL = 0,
       YELLOWJEWEL = 1,
       GARBAGEJEWEL = 2,
       COIN = 3,
       REVERSE = 4
   }

    public Consumable(items type, float damage, float health){
       this.type = type;
       this.damage = damage;
       this.health = health;
   }


}
