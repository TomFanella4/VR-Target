using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;
using VRTargetShooter.Core.Singletons;

public class StartupManager : Singleton<StartupManager>
{
    public bool isXR;

    public override void Awake()
    {
        base.Awake();
        if (XRGeneralSettings.Instance.InitManagerOnStart)
        {
            SceneManager.LoadScene("XRSetupScene");
            isXR = true;
        }
        else
        {
            SceneManager.LoadScene("MobileSetupScene");
            isXR = false;
        }
    }
}
