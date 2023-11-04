using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
    public Transform root;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    // Update is called once per frame
    void Update()
    {
        if(IsOwner)
        {
            root.position = VRRigReferences.Instance.root.position;
            root.rotation = VRRigReferences.Instance.root.rotation;

            head.position = VRRigReferences.Instance.head.position;
            head.rotation = VRRigReferences.Instance.head.rotation;

            leftHand.position = VRRigReferences.Instance.leftHand.position;
            leftHand.rotation = VRRigReferences.Instance.leftHand.rotation;

            rightHand.position = VRRigReferences.Instance.rightHand.position;
            rightHand.rotation = VRRigReferences.Instance.rightHand.rotation;
        }
    }
}
