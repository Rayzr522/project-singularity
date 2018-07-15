using UnityEngine;

class GUITools
{

    public static void FillRect(Rect position, Color color)
    {
        Texture2D texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        GUI.DrawTexture(position, texture);
    }

    public static void Healthbar(float percentage, Vector3 worldPosition, float heightAbove = 1.0f, float width = 100f, float height = 30f)
    {
        Vector3 point = Camera.main.WorldToScreenPoint(worldPosition + GameManager.instance.up.to3D() * heightAbove);
        point.y = Screen.height - point.y;

        FillRect(new Rect(point.x - width / 2, point.y - height / 2, width, height), Color.red);
        FillRect(new Rect(point.x - width / 2, point.y - height / 2, width * percentage, height), Color.green);
    }
}