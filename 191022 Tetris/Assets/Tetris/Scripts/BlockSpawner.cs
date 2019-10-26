using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    List<GameObject> blocks = new List<GameObject>();

    private void Awake()
    {
        blocks.Add(Resources.Load("Prefabs/IBlock") as GameObject);
        blocks.Add(Resources.Load("Prefabs/LBlock") as GameObject);
        blocks.Add(Resources.Load("Prefabs/RLBlock") as GameObject);
        blocks.Add(Resources.Load("Prefabs/RBlock") as GameObject);
        blocks.Add(Resources.Load("Prefabs/RRBlock") as GameObject);
        blocks.Add(Resources.Load("Prefabs/OBlock") as GameObject);
        blocks.Add(Resources.Load("Prefabs/MBlock") as GameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 자식 객체가 없다면
        if(transform.childCount == 0)
        {
            createBlock();
        }
    }

    private void createBlock()
    {
        int randomBlock = Random.Range(0, 6);
        GameObject newBlock = Instantiate(blocks[randomBlock]) as GameObject;
        newBlock.transform.SetParent(transform);
        newBlock.transform.localPosition = new Vector3(0, 0, 0);
    }
}
