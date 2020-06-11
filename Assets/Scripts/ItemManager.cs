using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{

    //items variables, remember all of them are 'Consumable'
    private Jewel greenJewel;
    private Jewel yellowJewel;
    private Jewel garbageJewel;
    private Coin coin;
    private Reverse reverse;

    //prefabs variables
    public GameObject Background;
    public GameObject CoinPrefab;
    public GameObject ReversePrefab;
    public GameObject GreenJewelPrefab;
    public GameObject YellowJewelPrefab;
    public GameObject GarbageJewelPrefab;

    // background dimensions
    private float rangeX, rangeY;

   //Create delegate. Any method that has the same signature as this can be assigned to this delegate.
   //Delegates are useful for multicast
   public delegate void ActionHit(Consumable.items type, int index);
   //Common usage of delegate, by assigning a variable
   public static event ActionHit onHit;
   
    void Start()
    {
        //create instances for jour jewels and coins
        greenJewel = new Jewel(Consumable.items.GREENJEWEL, Random.Range(1, 10), 0, 5);
        yellowJewel = new Jewel(Consumable.items.YELLOWJEWEL, Random.Range(1, 5), 5, 10);
        garbageJewel = new Jewel(Consumable.items.GARBAGEJEWEL, Random.Range(1, 3), 10, 0);
        coin = new Coin(Consumable.items.COIN, 100, 20); //cost is 100, health is 20
        reverse = new Reverse(Consumable.items.REVERSE, 0, 5); //cost is 100, health is 20

        //get the background
        rangeX = Background.GetComponent<SpriteRenderer>().sprite.bounds.extents.x * 0.8f;
        rangeY = Background.GetComponent<SpriteRenderer>().sprite.bounds.extents.y * 0.8f;
        //initialise all objects
        instantiate();

    }

    private void instantiate()
    {
        //instantiate
        for (int i = 0; i < greenJewel.amount; i++)
        {
            greenJewel.add(Instantiate(GreenJewelPrefab, new Vector2(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY)), Quaternion.identity));
        }
        //instantiate
        for (int i = 0; i < yellowJewel.amount; i++)
        {
            yellowJewel.add(Instantiate(YellowJewelPrefab, new Vector2(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY)), Quaternion.identity));
        }
        //instantiate
        for (int i = 0; i < garbageJewel.amount; i++)
        {
            garbageJewel.add(Instantiate(GarbageJewelPrefab, new Vector2(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY)), Quaternion.identity));
        }

        coin.create(Instantiate(CoinPrefab, new Vector2(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY)), Quaternion.identity));

    }


}
