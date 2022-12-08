using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMap 
{
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, int octaves, float scale, float lacunarity, float persitance, Vector2 offset)
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];
        Vector2[] octaveOfset = new Vector2[octaves];//making octaves come from differnt locations

        System.Random randNumGen = new System.Random(seed);
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = randNumGen.Next(-100000, 100000) + offset.x;
            float offsetY = randNumGen.Next(-100000, 100000) + offset.y;
            octaveOfset[i] = new Vector2(offsetX, offsetY);
        }

        if (scale <= 0)
        {
            scale = 0.001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = (x - halfWidth) / scale * frequency + octaveOfset[i].x;
                    float sampleY = (y - halfHeight) / scale * frequency + octaveOfset[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persitance;//persitance is between 0 and 1 menaing it decreases amplitude per octave
                    frequency *= lacunarity;//lacunarity is greater then 1 menaing frequency increases 
                }
                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }
                noiseMap[x, y] = noiseHeight;

            }
        }
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
                //inverse lerp returns a value between 0 and 1, normalizeing the noise map
            }
        }

        return noiseMap;

    }

   
}
