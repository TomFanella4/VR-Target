using Unity.Netcode;
using UnityEngine.SceneManagement;

public class PlayerProperties : NetworkBehaviour
{
    private NetworkVariable<bool> isXR = new();

    public bool getIsXR()
    {
        return isXR.Value;
    }

    [ServerRpc]
    public void setIsXRServerRpc(bool _isXR)
    {
        isXR.Value = _isXR;
    }
}
