using UnityEngine;
using System.Collections;
[System.Serializable]
public class Reverse : Consumable
{
    public int amount = 1;
    protected GameObject reverse;

    public Reverse(items type, int cost = 0, float health = 0) : base(type, 0, health)
    {
        // Subscribe to hit event
        ItemManager.onHit += hit;
    }

    public void create(GameObject _reverse){
       //_reverse.GetComponent<BasicObjectScript>().type = type;
       //_reverse.GetComponent<BasicObjectScript>().index = 0;
       this.reverse = _reverse;
   }

      public  void hit(items type, int index){
       if (type == this.type){
           reverse.SetActive(false);
           amount = 0;
       }
   }


}
