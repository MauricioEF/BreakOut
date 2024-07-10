using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject LevelCompleteMenu;

    int uncountableBlocks;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).GetComponent<Block>().countable)
            {
                uncountableBlocks++;
            }
        }
        Debug.Log(uncountableBlocks);
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.childCount -uncountableBlocks == 0)
        {
            LevelCompleteMenu.SetActive(true);
        }
    }
}
