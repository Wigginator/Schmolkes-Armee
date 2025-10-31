using UnityEngine;
using System.Collections.Generic;

public class ForestGeneratorWithMapPosition : MonoBehaviour
{
    public Texture2D mapTexture;
    public GameObject mainTreePrefab;
    public GameObject[] rareTreePrefabs; // 3 seltene Baumarten (im Inspector zuweisen)
    public int treeCount = 1000;
    public float treeRadius = 1f;
    public float rareTreeChance = 0.05f; // Wahrscheinlichkeit für seltene Bäume (z.B. 5%)

    // Werte aus deinem Sprite-Inspector:
    public Vector2 mapPosition = new Vector2(50, 50);        // Transform-Position des Sprites
    public float mapWorldSize = 10000f;                      // Seitenlänge des Sprites (bzw. Scale*Sprite-Pixel wenn skaliert)
    List<Vector2> placedPositions = new List<Vector2>();

    void Start()
    {
        // Berechnet die linke untere Ecke in Welt-Koordinaten
        Vector2 mapMin = mapPosition - Vector2.one * (mapWorldSize / 2f);

        for (int i = 0, tries = 0; i < treeCount && tries < treeCount * 10; tries++)
        {
            Vector2 pos = new Vector2(
                Random.Range(mapMin.x, mapMin.x + mapWorldSize),
                Random.Range(mapMin.y, mapMin.y + mapWorldSize)
            );

            // Texturkoordinaten berechnen
            int px = Mathf.RoundToInt((pos.x - mapMin.x) / mapWorldSize * (mapTexture.width - 1));
            int py = Mathf.RoundToInt((pos.y - mapMin.y) / mapWorldSize * (mapTexture.height - 1));
            if (px < 0 || py < 0 || px >= mapTexture.width || py >= mapTexture.height) continue;

            Color c = mapTexture.GetPixel(px, py);
            if (Mathf.Abs(c.r - Color.green.r) > 0.05f ||
                Mathf.Abs(c.g - Color.green.g) > 0.05f ||
                Mathf.Abs(c.b - Color.green.b) > 0.05f) continue;

            bool overlap = false;
            foreach (var p in placedPositions)
                if (Vector2.Distance(p, pos) < treeRadius * 2f) { overlap = true; break; }
            if (overlap) continue;

            placedPositions.Add(pos);
            GameObject prefab = mainTreePrefab;
            if (rareTreePrefabs.Length > 0 && Random.value < rareTreeChance)
                prefab = rareTreePrefabs[Random.Range(0, rareTreePrefabs.Length)];

            var tree = Instantiate(prefab, new Vector3(pos.x, pos.y, 0f), Quaternion.identity);
            tree.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(mapWorldSize - pos.y);
            i++;
        }
    }
}



