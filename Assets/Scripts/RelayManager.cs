using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Networking.Transport.Relay;
using VRTargetShooter.Core.Singletons;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class RelayManager : Singleton<RelayManager>
{
    private UnityTransport transport;

    // Start is called before the first frame update
    void Start()
    {
        transport = GetComponent<UnityTransport>();
    }

    public async void CreateRelayGame(int maxPlayer)
    {
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxPlayer);

        string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        Debug.Log("THE JOIN CODE IS : " + joinCode);

        RelayServerData serverData = new(allocation, "dtls");
        transport.SetRelayServerData(serverData);
        NetworkManager.Singleton.StartHost();

        NetworkManager.Singleton.SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public async void JoinRelayGame(string joinCode)
    {
        JoinAllocation allocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

        RelayServerData serverData = new(allocation, "dtls");
        transport.SetRelayServerData(serverData);
        NetworkManager.Singleton.StartClient();
    }
}
