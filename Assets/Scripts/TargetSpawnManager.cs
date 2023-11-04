using Unity.Netcode;
using UnityEngine;
using VRTargetShooter.Core.Singletons;

public class TargetSpawnManager : NetworkSingleton<TargetSpawnManager>
{
    [SerializeField]
    private GameObject prefab;

    [ServerRpc(RequireOwnership = false)]
    public void CreateTargetServerRpc(Vector3 worldCoordinates)
    {
        GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        go.transform.position = worldCoordinates;
        go.GetComponent<NetworkObject>().Spawn();
    }
}
