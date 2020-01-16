using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class InstSyncUnit : NetworkBehaviour
{

	public Camera camera;
	public GameObject unit;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isLocalPlayer)
			return;
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 100) && Input.GetMouseButtonDown (0)) {
			Cmd_Inst (hit.point);
		}
	}

	[Command]
	public void Cmd_Inst(Vector3 point) {
		GameObject unitInst = Instantiate (unit, point, Quaternion.identity);
		NetworkServer.Spawn (unitInst);
	}
}

