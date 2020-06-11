using UnityEngine;
using System.Collections;
[System.Serializable]
public class Coin : Consumable
{
    public int amount = 1;
    public int cost { get; private set; }
    protected GameObject coin;

    public Coin(items type, int cost, float health = 0) : base(type, 0, health)
    {
        this.cost = cost;

        // Subscribe to hit event
        ItemManager.onHit += hit;
    }

    public void create(GameObject coin)
    {
        //coin.GetComponent<BasicObjectScript>().type = type;
        //coin.GetComponent<BasicObjectScript>().index = 0;
        this.coin = coin;
    }

    //the method to be assigned to hit event delegate
    // index is ignored - used to match delegate signature
   public  void hit(items type, int index){
       if (type == this.type){
           coin.SetActive(false);
           amount = 0;
       }
   }

}
