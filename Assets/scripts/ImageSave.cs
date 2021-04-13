using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageSave : MonoBehaviour
{
    public RenderTexture texture;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            TakeScreenshot();
        }
        
    }

    public void TakeScreenshot()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Claimmate" + ".png");
        //File.WriteAllBytes(filePath, ToTexture2D(texture).EncodeToPNG());

       // new NativeShare().AddFile(filePath).Share();
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(ToTexture2D(texture).EncodeToPNG(), "Roofs & Ladders", "Image.png", (success, path) => Debug.Log("Media save result: " + success + " " + path));

        Debug.Log(filePath);
    }

    Texture2D ToTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
