using UnityEngine;

public class TargetCreationManager : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;

    private void OnEnable()
    {
        InputManager.Instance.OnStartTouch += CreateTarget;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnStartTouch -= CreateTarget;
    }

    public void CreateTarget(Vector2 screenPosition, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, playerCamera.farClipPlane);
        Vector3 worldCoordinates = playerCamera.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.y = Random.Range(2, 5);

        TargetSpawnManager.Instance.CreateTargetServerRpc(worldCoordinates);
    }
}
