using UnityEngine;

public class SimplexNoise2D : MonoBehaviour
{
    public float scale = 4f;
    public int width = 60;
    public int height = 60;

    private Texture2D noiseTexture;
    private Color[] noisePixels;

    private Noise.OpenSimplex2S noise;

    private void Start()
    {
        noise = new Noise.OpenSimplex2S(Random.Range(0, int.MaxValue));
        GenerateNoise();
    }

    private void GenerateNoise()
    {
        noiseTexture = new Texture2D(width, height);
        noisePixels = new Color[width * height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = (float)x / width * scale;
                float yCoord = (float)y / height * scale;

                float noiseValue = (float)noise.Noise2(xCoord, yCoord);

                noisePixels[x + y * width] = new Color(noiseValue, noiseValue, noiseValue);
            }
        }

        noiseTexture.SetPixels(noisePixels);
        noiseTexture.Apply();
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), noiseTexture);
    }
}
