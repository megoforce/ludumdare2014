////////////////////////////////////////////////////////////////////////////////////
//  CAMERA FILTER PACK - by VETASOFT 2014 //////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[AddComponentMenu ("Camera Filter Pack/Colors/HUE_Rotate")]
public class CameraFilterPack_Colors_HUE_Rotate : MonoBehaviour {
	#region Variables
	public Shader SCShader;
	public float HUE = 2.6f;
	private Vector4 ScreenResolution;
	private Material SCMaterial;


	#endregion
	
	#region Properties
	Material material
	{
		get
		{
			if(SCMaterial == null)
			{
				SCMaterial = new Material(SCShader);
				SCMaterial.hideFlags = HideFlags.HideAndDontSave;	
			}
			return SCMaterial;
		}
	}
	#endregion
	void Start () 
	{

		SCShader = Shader.Find("CameraFilterPack/Colors_HUE_Rotate");

		if(!SystemInfo.supportsImageEffects)
		{
			enabled = false;
			return;
		}
	}
	
	void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if(SCShader != null)
		{
			//TimeX+=Time.deltaTime;
			if (HUE>100)  HUE=0;
			material.SetFloat("_TimeX", HUE);
			material.SetFloat("_Speed", 1);
			material.SetVector("_ScreenResolution",new Vector2(Screen.width,Screen.height));
			Graphics.Blit(sourceTexture, destTexture, material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);	
		}
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Application.isPlaying)
		{
		}
		#if UNITY_EDITOR
		if (Application.isPlaying!=true)
		{
			SCShader = Shader.Find("CameraFilterPack/Colors_HUE_Rotate");

		}
		#endif

	}
	
	void OnDisable ()
	{
		if(SCMaterial)
		{
			DestroyImmediate(SCMaterial);	
		}
		
	}
	
	
}