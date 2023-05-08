using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
 
public class MapGen : MonoBehaviour
{
    public enum TileType
    {
        Floor,
        ShadowMid,
        SurroundOb,
        Obstacle
    }

    public static int mapWidth = 120;
    public static int mapHeight = 120;

    private TileType[,] mapTiles = new TileType[mapWidth, mapHeight];

    public float scale = 0.1f;

    public void Start()
    {
        GenerateMapTiles();
        RenderMapTiles();
    }

    void GenerateMapTiles()
    {
        Noise.OpenSimplex2S noise = new Noise.OpenSimplex2S(Random.Range(0,int.MaxValue));

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                float noiseValue = (float)noise.Noise2((float)x * scale, (float)y * scale);

                if (noiseValue < 0.7f)
                {
                    mapTiles[x, y] = TileType.Floor;
                }
                else if (noiseValue < 0.8f)
                {
                    mapTiles[x, y] = TileType.ShadowMid;
                }
                else if (noiseValue < 0.9f)
                {
                    mapTiles[x, y] = TileType.SurroundOb;
                }
                else
                {
                    mapTiles[x, y] = TileType.Obstacle;
                }
            }
        }
    }

    public Tilemap tilemap;
    public TileBase floorTile;
    public TileBase shadowMid;
    public TileBase surroundOb;
    public TileBase obstacleTile;
    public GameObject obstaclePrefab;
    Vector3 position = Vector3.zero;

    void RenderMapTiles()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                TileBase tile = null;

                switch (mapTiles[x, y])
                {
                    case TileType.Floor:
                        tile = floorTile;
                        break;
                    case TileType.ShadowMid:
                        tile = shadowMid;
                        break;
                    case TileType.SurroundOb:
                        tile = surroundOb;
                        break;
                    case TileType.Obstacle:
                        tile = obstacleTile;
                        position.x = x;
                        position.y = y;
                        Instantiate(obstaclePrefab, position, Quaternion.identity);
                        break;
                }

                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }
}
