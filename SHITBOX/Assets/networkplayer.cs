using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class networkplayer : NetworkBehaviour
{

    public Transform root;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    public Renderer[] meshToDisable;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
            if (IsOwner)
            {
                foreach (var item in meshToDisable)
                {
                    item.enabled = false;
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOwner)
        {
            root.position = VRRigReferences.Singleton.root.position;
            root.rotation = VRRigReferences.Singleton.root.rotation;

            head.position = VRRigReferences.Singleton.head.position;
            head.rotation = VRRigReferences.Singleton.head.rotation;

            leftHand.position = VRRigReferences.Singleton.lefthand.position;
            leftHand.rotation = VRRigReferences.Singleton.lefthand.rotation;

            rightHand.position = VRRigReferences.Singleton.righthand.position;
            rightHand.rotation = VRRigReferences.Singleton.righthand.rotation;
        }
    }
}
