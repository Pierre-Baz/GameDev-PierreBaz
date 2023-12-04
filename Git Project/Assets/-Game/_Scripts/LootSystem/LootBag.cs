using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public float dropForce;
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();

    Loot GetDroppedItem(){
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList){
            if(randomNumber <= item.dropChance){
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0){
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition){
        Loot droppedItem = GetDroppedItem();
        if(droppedItem != null){
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            Vector2 droppDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(droppDirection * dropForce, ForceMode2D.Impulse);
            // Set the GameObject's name to the lootName from the Loot script
            lootGameObject.name = droppedItem.lootName;
        }
    }
}
