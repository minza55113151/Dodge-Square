using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public static ItemManager instance;
    [SerializeField] private float itemDuration;
    [SerializeField] private Player player;
    [SerializeField] private GameObject destroyPrefab;
    [SerializeField] private EnemyInfo enemyInfo;
    
    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseItem(Item item)
    {
        //Debug.Log("UseItem: " + item.itemName);
        switch (item.itemName)
        {
            case "Destroy":
                GameObject destroy = Instantiate(destroyPrefab, item.transform.position, Quaternion.identity);
                Destroy(destroy, itemDuration);
                break;
            case "Slow":
                enemyInfo.speed /= 2f;
                Invoke("SlowReset", itemDuration);
                break;
            case "Speed":
                player.speed *= 1.5f;
                Invoke("SpeedReset", itemDuration);
                break;
        }
    }
    private void SlowReset()
    {
        enemyInfo.speed *= 2f;
    }
    private void SpeedReset()
    {
        player.speed /= 1.5f;
    }
}
