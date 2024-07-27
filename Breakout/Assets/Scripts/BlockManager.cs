using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject LevelCompleteMenu;
    public GameManager Manager;
    public float cameraWidth;
    public float cameraHeight;
    public Vector3 blockSize;
    private MeshRenderer blockRenderer;

    float blockWidth = 5;
    float blockHeight = 2;
    float startX;
    float startY= 20;
    float spaceBetweenX = 5;
    float spaceBetweenY = 5;
    int uncountableBlocks;

    public GameObject BaseBlock;
    public GameObject IceBlock;
    public GameObject StoneBlock;
    public GameObject WoodBlock;
    public GameObject MetalBlock;

    public Settings settings;

    // Start is called before the first frame update

    private void Awake()
    {
        InitializeBlocks();
    }
    void Start()
    {
        CalculateBlocksNumber();
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.childCount -uncountableBlocks == 0)
        {
            Manager.Pause();
            LevelCompleteMenu.SetActive(true);
        }
    }
    
    void InitializeBlocks()
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHeight = Camera.main.orthographicSize;
        float camWidth = 2.0f * screenAspect * camHeight;
        int random = Random.Range(1, 6);
        TextAsset asset = (TextAsset)Resources.Load($"{settings.DifficultyLevel}{random}");
        string[] rows = asset.text.Split('\n');

        for (int i = 0; i < rows.Length; i++)
        {
            startX = -(camWidth / 2);
            string[] blocks = rows[i].Trim().Split(",");
            float reservedSpace = (blocks.Length * blockWidth) + (spaceBetweenX * (blocks.Length - 1));
            float openSpace = camWidth - reservedSpace;
            startX += (openSpace / 2);

            for (int j = 0; j < blocks.Length; j++)
            {
                Debug.Log(blocks[j]);
                GameObject instance;
                switch (blocks[j])
                {
                    case "1":
                        instance = Instantiate(BaseBlock, new Vector3(startX + (blockWidth * j), startY + (blockHeight * i), -6), Quaternion.identity);
                        instance.transform.parent = this.gameObject.transform;
                        blockRenderer = instance.GetComponent<MeshRenderer>();
                        Debug.Log(blockRenderer.bounds.size);
                        break;
                    case "2":
                        instance = Instantiate(IceBlock, new Vector3(startX + (spaceBetweenX * j), startY + (blockHeight * i), -6), Quaternion.identity);
                        instance.transform.parent = this.gameObject.transform;
                        break;
                    case "3":
                        instance = Instantiate(WoodBlock, new Vector3(startX + (spaceBetweenX * j), startY + (blockHeight * i), -6), Quaternion.identity);
                        instance.transform.parent = this.gameObject.transform;
                        break;
                    case "4":
                        instance = Instantiate(StoneBlock, new Vector3(startX + (spaceBetweenX * j), startY + (blockHeight * i), -6), Quaternion.identity);
                        instance.transform.parent = this.gameObject.transform;
                        break;
                    case "5":
                        instance = Instantiate(MetalBlock, new Vector3(startX + (spaceBetweenX * j), startY + (blockHeight * i), -6), Quaternion.identity);
                        instance.transform.parent = this.gameObject.transform;
                        break;
                    case "X":
                        break;
                }
                startX += spaceBetweenX;
            }
            startY -= spaceBetweenY;
        }
    }

    void CalculateBlocksNumber()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).GetComponent<Block>().countable)
            {
                uncountableBlocks++;
            }
        }
        Debug.Log(uncountableBlocks);
    }

    public void Reset()
    {
        startY = 20;
        InitializeBlocks();
        CalculateBlocksNumber();
    }
}
