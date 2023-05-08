using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
 
public class ObstacleGen : MonoBehaviour
{
    public enum TileType
    {
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

                if (noiseValue >= 0.9f)
                {
                    mapTiles[x, y] = TileType.Obstacle;
                }
            }
        }
    }

    public Tilemap tilemap;
    public TileBase obstacleTile;

    void RenderMapTiles()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                TileBase tile = null;

                switch (mapTiles[x, y])
                {
                    case TileType.Obstacle:
                        tile = obstacleTile;
                        break;
                }

                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }
}