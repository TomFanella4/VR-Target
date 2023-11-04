using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;
using VRTargetShooter.Core.Singletons;

public class PlayerSpawnManager : NetworkSingleton<PlayerSpawnManager>
{
    [SerializeField]
    private GameObject xrPlayer;

    [SerializeField]
    private GameObject mobilePlayer;

    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (ulong clientId) =>
        {
            if (clientId == NetworkManager.Singleton.LocalClientId)
            {
                var PlayerProperties = NetworkManager.Singleton.LocalClient.PlayerObject.GetComponentInChildren<PlayerProperties>();
                var isXR = StartupManager.Instance.isXR;

                PlayerProperties.setIsXRServerRpc(isXR);
                if (isXR)
                {
                    CreateXRPlayerServerRpc();
                }
                else
                {
                    Instantiate(mobilePlayer);
                }
            }
        };
    }

    [ServerRpc(RequireOwnership = false)]
    public void CreateXRPlayerServerRpc()
    {
        GameObject go = Instantiate(xrPlayer);
        go.GetComponent<NetworkObject>().Spawn();
    }
}
