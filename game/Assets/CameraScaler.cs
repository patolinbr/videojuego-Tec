using UnityEngine;
using System.Collections.Generic;

public class CameraScaler : MonoBehaviour
{
    private int ScreenSizeX = 0;
    private int ScreenSizeY = 0;
    private Camera cameraComponent;

    private void RescaleCamera()
    {
        if (Screen.width == ScreenSizeX && Screen.height == ScreenSizeY) return;

        float targetaspect = 16.0f / 9.0f;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;

        if (scaleheight < 1.0f)
        {
            Rect rect = cameraComponent.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            cameraComponent.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = cameraComponent.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            cameraComponent.rect = rect;
        }

        ScreenSizeX = Screen.width;
        ScreenSizeY = Screen.height;
    }

    void OnPreCull()
    {
        if (Application.isEditor) return;
        Rect wp = cameraComponent.rect;
        Rect nr = new Rect(0, 0, 1, 1);

        cameraComponent.rect = nr;
        GL.Clear(true, true, Color.black);

        cameraComponent.rect = wp;
    }

    // Use this for initialization
    void Start()
    {
        cameraComponent = GetComponent<Camera>();
        RescaleCamera();
    }

    // Update is called once per frame
    void Update()
    {
        RescaleCamera();
    }
}