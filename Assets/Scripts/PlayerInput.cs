using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	public bool gamepadOn;
	public XboxController gamepad;

	public Vector2 directionalInput;
	public Vector2 directionalGamepadInput;

	float x;
	float y;

	Player player;

	void Start () {
		player = GetComponent<Player> ();
	}

	void Update () {

		if (XCI.GetButtonDown(XboxButton.Back) && !gamepadOn)
		{
			gamepadOn = true;
			Debug.Log("Gamepad: " + gamepadOn);
		} else if (XCI.GetButtonDown(XboxButton.Back) && gamepadOn)
		{
			gamepadOn = false;
			Debug.Log("Gamepad: " + gamepadOn);
		}

		if (!gamepadOn)
		{
			directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			player.SetDirectionalInput (directionalInput);

			if (Input.GetKeyDown (KeyCode.Space)) {
			player.OnJumpInputDown ();
			}

			if (Input.GetKeyUp (KeyCode.Space)) {
			player.OnJumpInputUp ();
			}
		}

		if (gamepadOn)
		{
			x = XCI.GetAxisRaw(XboxAxis.LeftStickX);
			y = XCI.GetAxisRaw(XboxAxis.LeftStickY);

			directionalGamepadInput = new Vector2 (x, y);
			player.SetDirectionalInput(directionalGamepadInput);

			if (XCI.GetButtonDown(XboxButton.A))
			{
				player.OnJumpInputDown();
			}

			if (XCI.GetButtonUp(XboxButton.A))
			{
				player.OnJumpInputUp();
			}
		}

		
	}
}
