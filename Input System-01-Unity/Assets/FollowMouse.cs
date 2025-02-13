using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        Vector3 worldPosition = SceneToWorld(movementVector);
        
        UpdateObjectPosition(worldPosition.x, worldPosition.y);
    }


    private Vector3 SceneToWorld(Vector2 screenPoints)
    {
      Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPoints.x, screenPoints.y, Camera.main.transform.position.z));  
      return worldPosition;
    }


    private void UpdateObjectPosition(float xPosition, float yPosition)
    {
        Vector3 pos = transform.position;
        pos.x = xPosition;
        pos.y = yPosition;
        transform.position = pos;
    }





}
