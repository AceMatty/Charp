using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerSync : NetworkBehaviour
{

	[SyncVar]
	private Vector3 syncPosition;
	public float lerpSpeed = 20f;
	
	void FixedUpdate ()
	{
		LerpPosition ();
		TransmitPosition ();
	}

	void LerpPosition() {
		if (!isLocalPlayer) {
			transform.position = Vector3.Lerp (transform.position, syncPosition, Time.deltaTime * lerpSpeed);
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
		syncPosition = pos;
	}
}

