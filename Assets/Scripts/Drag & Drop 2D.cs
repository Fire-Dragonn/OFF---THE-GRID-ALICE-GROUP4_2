using UnityEditor.Build;
using UnityEngine;
 
public class DragDrop2D : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "DropArea";

    public enum TokenType { Purple, Bronze, Grey };
    public TokenType tokenType;
    public static int purpleTokenCount = 5;
    public static int BronzeTokenCount = 5;
    public static int GreyTokenCount;
    public static int maxTokenCount = 10;
    public static bool isPlayerTurn = true;
    public static bool isgamePaused = false;
 
    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }
 
    void OnMouseDown()
    { if (CanSpawnToken(tokenType))
        {
          offset = transform.position - MouseWorldPosition();
        }
        else
        {
            Debug.LogWarning("Maximum token reached!");
        }
    }
        
 
    void OnMouseDrag()
    { 
        if (CanDrag() && isPlayerTurn && isgamePaused)
        {
          transform.position = MouseWorldPosition() + offset;
        }
        
    }
 
    void OnMouseUp()
    {
        collider2d.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo;
        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {    
            
            if (hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);
            }
        }
        collider2d.enabled = true;
    }
 
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
    bool CanSpawnToken(TokenType type)
    {
        switch (type)
        {
            case TokenType.Purple:
                return purpleTokenCount < maxTokenCount;
            case TokenType.Bronze:
                return BronzeTokenCount < maxTokenCount;
            case TokenType.Grey:
                return GreyTokenCount < maxTokenCount;
                default: return false;

        }
    }

    bool CanDrag()
    {
        return true;
    }
    public static void SwitchTurn()
    {
        isPlayerTurn = !isPlayerTurn;
    }
    public static void SetGamePaused(bool gamePaused)
    {
        isgamePaused = gamePaused;
    }
}