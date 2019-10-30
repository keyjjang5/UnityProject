using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    private List<GameObject> blocks = new List<GameObject>();

    private GameObject nextBlock;
    private BlockController nBController;

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
        nextBlock = GameObject.Find("NextBlock/NextBlockSpawn");
        createBlock();
    }

    // Update is called once per frame
    void Update()
    {
        // 자식 객체가 있다면
        if (transform.childCount != 0)
            return;

        getBlock();
    }

    private void getBlock()
    {
        if (nextBlock.transform.childCount == 0)
            return;

        Transform next = nextBlock.transform.GetChild(0);
        next.SetParent(transform);
        next.position = transform.position;
        next.GetComponent<BlockController>().setIsActive(true);

        createBlock();
    }

    private void createBlock()
    {
        int randomBlock = Random.Range(0, 6);
        GameObject newBlock = Instantiate(blocks[randomBlock]) as GameObject;
        nBController = newBlock.GetComponent<BlockController>();

        newBlock.transform.SetParent(nextBlock.transform);
        newBlock.transform.localPosition = new Vector3(0, 0, 0);
        nBController.setIsActive(false);
    }
}
