using Unity.Netcode;
using UnityEngine;

public class PlayerTouchHandler : NetworkBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Camera playerCamera;

    private InputManager inputManager;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += Move;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= Move;
    }

    public void Move(Vector2 screenPosition, float time)
    {
        if (IsClient && IsOwner)
        {
            Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, playerCamera.farClipPlane);
            Vector3 worldCoordinates = playerCamera.ScreenToWorldPoint(screenCoordinates);
            worldCoordinates.y = Random.Range(2, 5);

            CreateTargetServerRpc(worldCoordinates);
        }
    }

    [ServerRpc]
    public void CreateTargetServerRpc(Vector3 worldCoordinates)
    {
        GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        go.transform.position = worldCoordinates;
        go.GetComponent<NetworkObject>().Spawn();
    }
}
