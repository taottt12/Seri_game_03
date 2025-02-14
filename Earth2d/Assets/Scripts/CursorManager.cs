using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorShot;
    [SerializeField] private Texture2D cursorReLoad;
    private Vector2 hostpos = new Vector2(16, 48);

    void Start()
    {
        Cursor.SetCursor(cursorNormal, hostpos, CursorMode.Auto);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Cursor.SetCursor(cursorShot, hostpos, CursorMode.Auto);
        }else if(Input.GetMouseButtonUp(0)){
            Cursor.SetCursor(cursorNormal, hostpos, CursorMode.Auto);
        }

        if(Input.GetMouseButtonDown(1)){
            Cursor.SetCursor(cursorReLoad, hostpos, CursorMode.Auto);
        }else if(Input.GetMouseButtonUp(1)){
            Cursor.SetCursor(cursorNormal, hostpos, CursorMode.Auto);
        }
    }
}
