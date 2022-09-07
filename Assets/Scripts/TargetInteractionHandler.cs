using Unity.Netcode;
using UnityEngine;

public class TargetInteractionHandler : NetworkBehaviour
{
    public void DestroyTarget()
    {
        DestroyTargetServerRpc();
        DestroyTargetClientRpc();
    }

    [ServerRpc]
    public void DestroyTargetServerRpc()
    {
        gameObject.SetActive(false);
    }

    [ClientRpc]
    public void DestroyTargetClientRpc()
    {
        gameObject.SetActive(false);
    }
}
