using UnityEngine;
using System.Collections;
using InControl;

public class CustomInputData : MonoBehaviour {
	void Start()
	{
		SetCustomInput();
	}
	
	
	public static void SetCustomInput()
	{
		UICamera.onCustomInput = CustomInput;
	}
	
	
	public static void CustomInput()
	{
		if (UICamera.selectedObject == null)
		{
			return;
		}
		
		//The default NGUI cancel key is KeyCode.JoystickButton1 and will cause
		//NGUI to intercept this and set the selected object to null
		//before we get a chance to interpret the input. Setting it to
		//KeyCode.None will cause it to ignore that test.
		UICamera.current.cancelKey1 = KeyCode.None;
		
		InputDevice device = InputManager.ActiveDevice;
		
		if (device.Action1.WasPressed)
		{
			UICamera.selectedObject.SendMessage( "OnClick" ,SendMessageOptions.DontRequireReceiver);
		}
		
		if (device.Direction.Up.WasPressed)
		{
			UICamera.currentScheme = UICamera.ControlScheme.Controller;
			UICamera.selectedObject.SendMessage( "OnKey", KeyCode.UpArrow ,SendMessageOptions.DontRequireReceiver);
		}
		
		if (device.Direction.Down.WasPressed)
		{
			UICamera.currentScheme = UICamera.ControlScheme.Controller;
			UICamera.selectedObject.SendMessage( "OnKey", KeyCode.DownArrow ,SendMessageOptions.DontRequireReceiver);
		}
		
		if (device.Direction.Right.WasPressed)
		{
			UICamera.currentScheme = UICamera.ControlScheme.Controller;
			UICamera.selectedObject.SendMessage( "OnKey", KeyCode.RightArrow ,SendMessageOptions.DontRequireReceiver);
		}
		
		if (device.Direction.Left.WasPressed)
		{
			UICamera.currentScheme = UICamera.ControlScheme.Controller;
			UICamera.selectedObject.SendMessage( "OnKey", KeyCode.LeftArrow ,SendMessageOptions.DontRequireReceiver);
		}
	}
}
