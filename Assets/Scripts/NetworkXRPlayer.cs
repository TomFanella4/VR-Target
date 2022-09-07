using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkXRPlayer : NetworkBehaviour
{
    [SerializeField]
    private Vector3 placementArea = new Vector2(-10.0f, 10.0f);

    public override void OnNetworkSpawn()
    {
        DisableClientInput();
    }

    public void DisableClientInput()
    {
        if (IsClient && !IsOwner)
        {
            var clientControllers = GetComponentsInChildren<ActionBasedController>();
            var clientTurnProvider = GetComponent<ActionBasedSnapTurnProvider>();
            var clientHead = GetComponentInChildren<TrackedPoseDriver>();
            var clientCamera = GetComponentInChildren<Camera>();
            var audioListener = GetComponentInChildren<AudioListener>();

            clientCamera.enabled = false;
            audioListener.enabled = false;
            clientTurnProvider.enableTurnLeftRight = false;
            clientTurnProvider.enableTurnAround = false;
            clientHead.enabled = false;

            foreach (var controller in clientControllers)
            {
                controller.enableInputActions = false;
                controller.enableInputTracking = false;
            }
        }
    }

    private void Start()
    {
        if (IsClient && IsOwner)
        {
            transform.position = new Vector3(Random.Range(placementArea.x, placementArea.y), transform.position.y,
                Random.Range(placementArea.x, placementArea.y));
        }
    }
}
