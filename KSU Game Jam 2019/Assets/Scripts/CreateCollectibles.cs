using System;
using System.IO;
using UnityEngine;
using Light2D;
using System.Collections.Generic;

public class CreateCollectibles : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();
    public List<GameObject> Lights = new List<GameObject>();
    private GameObject grid;
    private Vector2[] UsedPositions;
    private Vector2 currentPosition;
    private int index;
    private int MinItemCount = 2;
    private int MaxItemCount = 10;
    private Sprite image;

    public int ItemCount;
    public string ItemType;
    public Vector2[] AcceptablePositions;
    public Sprite LightSprite;
    public Material LightMaterial;

    void Start()
    {

        ItemCount = GetValidItemCount(ItemCount);
        UsedPositions = new Vector2[ItemCount];
        grid = GameObject.Find("Grid");

        for (int i = 0; i < ItemCount; i++)
        {
            bool newPosition = false;
            while (!newPosition)
            {
                index = UnityEngine.Random.Range(0, AcceptablePositions.Length);
                if (NewPosition(AcceptablePositions[index]))
                {
                    currentPosition = AcceptablePositions[index];
                    UsedPositions[i] = currentPosition;
                    newPosition = true;
                }
            }

            foreach (string file in Directory.GetFiles(Application.dataPath + "/Sprites/Items/"))
            {
                if (!file.ToString().Contains(".meta") && file.ToString().Contains(ItemType+".png"))
                {
                    Texture2D imageFile = LoadPNG(file.ToString());
                    imageFile.filterMode = FilterMode.Point;
                    int image_max_x = imageFile.width;
                    int image_max_y = imageFile.height;
                    int startX = GetStartX(image_max_x);
                    int startY = GetStartY(image_max_y);
                    Rect rect = new Rect();
                    rect.xMin = startX;
                    rect.yMin = startY;
                    rect.xMax = startX + 16;
                    rect.yMax = startY + 16;
                    image = Sprite.Create(imageFile, rect, new Vector2(0, 0));
                }
            }
            GameObject newItem = new GameObject("Collectible Item "+i);
            newItem.transform.SetParent(grid.transform);
            newItem.transform.position = new Vector3(currentPosition.x, currentPosition.y, 0);
            newItem.transform.localScale = new Vector3(5, 5, 0);
            newItem.AddComponent<Bobbing>();
            newItem.AddComponent<SpriteRenderer>();
            newItem.GetComponent<SpriteRenderer>().sprite = image;
            newItem.GetComponent<SpriteRenderer>().sortingLayerName = "Midground";
            Items.Add(newItem);

            GameObject newLight = new GameObject("Item " + i + " Light");
            newLight.transform.SetParent(GameObject.Find("Collectible Item " + i).transform);
            newLight.AddComponent<LightSprite>();
            newLight.GetComponent<LightSprite>().Sprite = LightSprite;
            newLight.GetComponent<LightSprite>().Material = LightMaterial;
            newLight.layer = 8;
            newLight.GetComponent<LightSprite>().Color.a = .25f;
            Lights.Add(newLight);

        }
    }

    void Update()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            float currentX = Items[i].transform.position.x + .5f;
            float currentY = Items[i].transform.position.y + .5f;
            Lights[i].transform.position = new Vector3(currentX, currentY, 0);
        }

    }

    public int GetStartX(int max_x)
    {
        int startX = 0;
        bool valid_x_coord = false;
        while (!valid_x_coord)
        {
            int image_count = max_x / 16;
            startX = UnityEngine.Random.Range(0, image_count);
            if ((startX*16) + 16 <= max_x)
            {
                valid_x_coord = true;
            }
        }
        return startX*16;
    }

    public int GetStartY(int max_y)
    {
        int startY = 0;
        bool valid_y_coord = false;
        while (!valid_y_coord)
        {
            int image_count = max_y / 16;
            startY = UnityEngine.Random.Range(0, image_count);
            if ((startY*16) + 16 <= max_y)
            {
                valid_y_coord = true;
            }
        }
        return startY*16;
    }

    public int GetValidItemCount(int count)
    {
        if (count < MinItemCount)
        {
            count = 1;
        }
        else if (count > MaxItemCount)
        {
            count = 10;
        } else if (count > AcceptablePositions.Length)
        {
            count = AcceptablePositions.Length;
        }
        return count;
    }

    public static Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); 
        }
        return tex;
    }

    public bool NewPosition(Vector2 currentPosition)
    {
        bool newPosition = true;
        if (UsedPositions.Length > 0)
        {
            try
            {
                foreach (Vector2 position in UsedPositions)
                {
                    if (currentPosition.x == position.x && currentPosition.y == position.y)
                    {
                        newPosition = false;
                    }
                }
            } catch (NullReferenceException ex)
            {
                Debug.Log(ex);
            }
        }
        return newPosition;
    }
}

