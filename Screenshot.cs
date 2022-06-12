using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Screenshot : MonoBehaviour 
{
  void Start() 
  {
    StartCoroutine(CoroutineScreenshot());
  }
  
  private IEnumerator CoroutineScreenshot()
  {
    yield return new WaitForEndOfFrame();
    int width = Screen.width;
    int height = Screen.height;
    Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
    Rect rect = new Rect(0, 0, width, height);
    tex.ReadPixels(rect, 0, 0);
    tex.Apply();
    byte[] bytes = tex.EncodeToPNG();
    ImageDownloader(System.Convert.ToBase64String(bytes), "screenshot.png");
  }
}
