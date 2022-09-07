using Unity.Netcode;
using UnityEngine;

public class NetworkMobilePlayer : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        DisableClientInput();
    }

    public void DisableClientInput()
    {
        if (IsClient && !IsOwner)
        {
            var clientCamera = GetComponentInChildren<Camera>();
            var audioListener = GetComponentInChildren<AudioListener>();

            clientCamera.enabled = false;
            audioListener.enabled = false;
        }
    }
}
