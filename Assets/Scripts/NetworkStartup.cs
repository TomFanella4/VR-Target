using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

public class NetworkStartup : MonoBehaviour
{
    private void Start()
    {
        _ = SetupRelayNetwork();
    }

    private async Task SetupRelayNetwork()
    {
        byte playerPrefabHash = (byte)(SceneTransitionHandler.Instance.isXR ? 1 : 2);
        byte[] connectionData = new byte[1] { playerPrefabHash };
        NetworkManager.Singleton.NetworkConfig.ConnectionData = connectionData;

        if (SceneTransitionHandler.Instance.InitializeAsHost)
        {
            if (RelayManager.Instance.IsRelayEnabled)
                await RelayManager.Instance.SetupRelay();

            NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
            NetworkManager.Singleton.StartHost();
        }
        else
        {
            string joinCode = SceneTransitionHandler.Instance.joinCode;
            if (RelayManager.Instance.IsRelayEnabled)
                await RelayManager.Instance.JoinRelay(joinCode);

            NetworkManager.Singleton.StartClient();
        }
    }

    private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {
        // The client identifier to be authenticated
        var clientId = request.ClientNetworkId;

        // Additional connection data defined by user code
        var connectionData = request.Payload;

        // Your approval logic determines the following values
        response.Approved = true;
        response.CreatePlayerObject = true;

        // The prefab hash value of the NetworkPrefab, if null the default NetworkManager player prefab is used
        int playerPrefabHash = connectionData[0];
        response.PlayerPrefabHash = System.Convert.ToUInt32(playerPrefabHash);
        //Logger.Instance.LogInfo($"Client: {clientId} Hash: {playerPrefabHash}");

        // Position to spawn the player object (if null it uses default of Vector3.zero)
        //response.Position = Vector3.zero;

        // Rotation to spawn the player object (if null it uses the default of Quaternion.identity)
        //response.Rotation = Quaternion.identity;

        // If additional approval steps are needed, set this to true until the additional steps are complete
        // once it transitions from true to false the connection approval response will be processed.
        response.Pending = false;
    }
}
