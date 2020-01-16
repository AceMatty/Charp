using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncUnit : NetworkBehaviour {

	[SyncVar]
	private Vector3 syncPos;

	// Use this for initialization
	void Start () {
		syncPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isClient) {
			transform.position = Vector3.Lerp (transform.position, syncPos, 5 * Time.deltaTime);
		}
	}

	[Client]
	void TransmitPosition() {
		if (isLocalPlayer) {
			CmdSendPosition (transform.position);
		}
	}

	[Command]
	void CmdSendPosition(Vector3 pos) {
		syncPos = pos;
	}
}
