using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CanvasNetwork : NetworkBehaviour {

    private void Start()
    {
        if(isServer)
        {
            return;
        }
    }
}
