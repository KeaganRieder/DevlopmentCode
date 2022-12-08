using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageHandler 
{
    public int mapWidth;
    public int mapHeight;
    public int scale;
    public int seed;
    public int octaves;
    public float amplitude;
    public float frequency;
    public static float[,] noiseMap;
    // public static float[,] StarMap;
    Dictionary<int, Vector2Int> StarMapCords; //int is the star, and key is the cords
    Dictionary<int, Color> StarMapColor;
    Texture2D artTexture;
    int lsatStar = 0;



    public void CreateDrawing(Renderer renderer)
    {
        //randominizing settings for certain gen varibles
        //setting vars to draw
        amplitude = Random.Range(0f, .5f);
        frequency = Random.Range(.1f, 2.3f);
        seed = Random.Range(1, 5000);
        noiseMap = NoiseMap.GenerateNoiseMap(mapWidth, mapHeight, seed, octaves, scale, frequency, amplitude, new Vector2(0, 0));
        StarMapCords = new Dictionary<int, Vector2Int>();
        StarMapColor = new Dictionary<int, Color>();
        lsatStar = 0;

        //drawing
        artTexture = DrawNebula();
        artTexture.filterMode = FilterMode.Point;
        renderer.material.mainTexture = artTexture;
        //artTexture = text

    }

    public void SetDefaultSettings()
    {
        
        mapWidth = 100;
        mapHeight = 100;
        octaves = 50;
        scale = 50;
        //amplitude = .286f;
        //frequency = 2.5f;
        //seed = 20;
        artTexture = new(100, 100);


    }   

    private Texture2D DrawNebula()
    {
        int currentStar = 0;
        Texture2D texture = new(mapWidth, mapHeight);
        Color nebulaBaseColor = new(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Color nebulaBaseColor2 = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Color nebulaBaseColor3 = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Color nebulaBaseColor4 = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Color nebulaBaseColor5 = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        //Color nebulaBaseColorMix = new(nebulaBaseColor.r - (nebulaBaseColor2.r *.5f) , nebulaBaseColor.g-(nebulaBaseColor2.g * .5f), nebulaBaseColor.b- (nebulaBaseColor2.b * .5f));
        Color nebulaBaseColor12Mix = new(Random.Range(nebulaBaseColor.r, nebulaBaseColor2.r), Random.Range(nebulaBaseColor.g, nebulaBaseColor2.g), Random.Range(nebulaBaseColor.b, nebulaBaseColor2.b));
        Color nebulaBaseColor23Mix = new(Random.Range(nebulaBaseColor3.r, nebulaBaseColor2.r), Random.Range(nebulaBaseColor3.g, nebulaBaseColor2.g), Random.Range(nebulaBaseColor3.b, nebulaBaseColor2.b));
        Color nebulaBaseColor34Mix = new(Random.Range(nebulaBaseColor3.r, nebulaBaseColor4.r), Random.Range(nebulaBaseColor3.g, nebulaBaseColor4.g), Random.Range(nebulaBaseColor3.b, nebulaBaseColor4.b));
        Color nebulaBaseColor45Mix = new(Random.Range(nebulaBaseColor5.r, nebulaBaseColor4.r), Random.Range(nebulaBaseColor5.g, nebulaBaseColor4.g), Random.Range(nebulaBaseColor5.b, nebulaBaseColor4.b));

        Color starColor = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Color starColor1 = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Color starColor2 = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Color starColor3 = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Color starColor4 = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                int placeStar = Random.Range(0, 60);
                var height = noiseMap[x, y];
                Color pixelColor;
                
                //this is swaped due to minusing hight from the element so first if is the lightest, and the last one is teh darkets
                if (height <= Random.Range(0f,.2f))
                {
                    //pixelColor = new(1, 1, 1);
                    pixelColor = new(nebulaBaseColor.r - height, nebulaBaseColor.g - height, nebulaBaseColor.b - height);
                }
                else if (height <= Random.Range(.2f,.3f))
                {
                    pixelColor = new(nebulaBaseColor12Mix.r - height, nebulaBaseColor12Mix.g - height, nebulaBaseColor12Mix.b - height);
                }
                else if (height <= Random.Range(.3f, .4f))
                {
                    pixelColor = new(nebulaBaseColor2.r - height, nebulaBaseColor2.g - height, nebulaBaseColor2.b - height);
                }
                else if (height <= Random.Range(.4f, .5f))
                {
                    pixelColor = new(nebulaBaseColor23Mix.r - height, nebulaBaseColor23Mix.g - height, nebulaBaseColor23Mix.b - height);
                }
                else if (height <= Random.Range(.5f,.6f))
                {
                    pixelColor = new(nebulaBaseColor3.r - height, nebulaBaseColor3.g - height, nebulaBaseColor3.b - height);
                }
                else if (height <= Random.Range(.6f, .7f))
                {
                    pixelColor = new(nebulaBaseColor34Mix.r - height, nebulaBaseColor34Mix.g - height, nebulaBaseColor34Mix.b - height);
                }
                else if (height <= Random.Range(.7f, .8f))
                {
                    pixelColor = new(nebulaBaseColor4.r - height, nebulaBaseColor4.g - height, nebulaBaseColor4.b - height);
                }
                else if (height <= Random.Range(.8f, .9f))
                {
                    //pixelColor = new(1, 1, 1);

                    pixelColor = new(nebulaBaseColor45Mix.r -= height, nebulaBaseColor45Mix.g -= height, nebulaBaseColor45Mix.b -= height);
                }
                else if (height <= Random.Range(.9f, 1f))
                {
                    //pixelColor = new(1, 1, 1);
                    pixelColor = new(nebulaBaseColor5.r -= height, nebulaBaseColor5.g -= height, nebulaBaseColor5.b -= height);
                }
                else
                {
                    pixelColor = new(nebulaBaseColor.r - height, nebulaBaseColor.g - height, nebulaBaseColor.b - height);
                }
                //placing stars
                if (pixelColor.r <= 0&& pixelColor.g  <= 0&& pixelColor.b  <= 0)
                {
                    if (placeStar <= 5)
                    {

                        int color = Random.Range(0, 7);
                        //pixelColor = new Color(1, 1, 1);
                        StarMapCords.Add(currentStar, new(x, y));
                        if (color == 0)
                        {
                            pixelColor = new Color(starColor.r - .5f, starColor.g - .5f, starColor.b - .5f);
                           
                        }
                        else if (color == 1)
                        {
                            pixelColor = new Color(starColor1.r - .5f, starColor1.g - .5f, starColor1.b - .5f);
                        }
                        else if (color == 2)
                        {
                            pixelColor = new Color(starColor2.r - .5f, starColor2.g - .5f, starColor2.b - .5f);
                        }
                        else if (color == 3)
                        {
                            pixelColor = new Color(starColor3.r - .5f, starColor3.g - .5f, starColor3.b - .5f);
                        }
                        else
                        {
                            pixelColor = new Color(1-.3f , 1 - .3f, 1 - .3f);
                        }
                        StarMapColor.Add(currentStar, pixelColor);
                        currentStar++;
                    }
                }

                texture.SetPixel(x, y, pixelColor);

            }
        }
       // texture.filterMode = FilterMode.Point;
        texture.Apply();
        return texture;
    }

    public Texture2D BlinkStar()
    {
        //unblinking last star
        Vector2Int currentCords = StarMapCords[lsatStar];
        Debug.Log("unblicking star at " + currentCords.x + " " + currentCords.y);
        artTexture.SetPixel(currentCords.x, currentCords.y, StarMapColor[lsatStar]);

        //finding next star to blink
        lsatStar = Random.Range(0, StarMapCords.Count);
        currentCords = StarMapCords[lsatStar];
        Debug.Log("blicking star at " + currentCords.x + " " + currentCords.y);
        
        artTexture.SetPixel(currentCords.x, currentCords.y, new(0, 0, 0));
        
        
        artTexture.Apply();
        return artTexture;
    }

    //maybe make a combo
}
