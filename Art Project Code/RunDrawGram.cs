using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunDrawGram : MonoBehaviour
{
    private ImageHandler drawingStuff = new();
    public Renderer canvasRender;
    public GameObject planet;
    bool autoRun = false;
    int timer = 0;
    int starBlinkInterval = 0;
    bool Drawing = true;

    // Start is called before the first frame update
    void Start()
    {
        drawingStuff.SetDefaultSettings();
        //canvasRender = GetComponent<Renderer>();
        canvasRender = transform.GetComponent<Renderer>();
        //planet = GameObject.Find("planet");
        drawingStuff.CreateDrawing(canvasRender);
        Drawing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Drawing = true;
            starBlinkInterval = 0;
            drawingStuff.CreateDrawing(canvasRender);
            Drawing = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            autoRun = !autoRun;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void FixedUpdate()
    {
        if (!Drawing)
        {
            starBlinkInterval++;
        }
        
        if (autoRun)
        {
            timer += 1;
            if (timer >= 300)
            {
                Drawing = true;
                starBlinkInterval = 0;
                timer = 0;
                drawingStuff.CreateDrawing(canvasRender);
                Drawing = false;
            }
            //Debug.Log(timer);
        }
        //Debug.Log(starBlinkInterval);
        if (starBlinkInterval >= 10 && !Drawing)
        {
            canvasRender.material.mainTexture = drawingStuff.BlinkStar();
            starBlinkInterval = 0;
        }
        
    }
}
