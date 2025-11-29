using JetBrains.Annotations;
using UnityEditorInternal;
using UnityEngine;

public class Parallax_Background : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;               // Get Background Pos
        Vector2 pos1 = new Vector2(0.0f, pos.y);        // Setup Mountains Pos
        Vector2 pos2 = new Vector2(0.0f, pos.y);        // Setup Clouds Pos
        pos1.x = pos.x - (pos.x * 0.75f) % 16;          // Calc Mountains Pos
        pos2.x = pos.x - (pos.x * 0.5f) % 16;           // Calc Clouds Pos
        transform.Find("Mointains").position = pos1;    // Update Mointain Pos
        transform.Find("Clouds").position = pos2;       // Update Clouds Pos
    }
}
