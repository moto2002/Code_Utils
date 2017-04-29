/**
 * 文件名:BuildPostprocessor.cs
 * 对assets/bin/Data/Managed/Assembly-CSharp.dll进行解密
 * **/

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;

public class BuildPostprocessor
{
	static string version = "5.3";

	[MenuItem ("Tools/Decrytion")]
	public static void Decryption ()
	{

		string[] dlls = {
			"Assembly-CSharp.dll",
			"MobaClient.dll",
			"MobaProtocol.dll",
			"Assembly-CSharp-firstpass.dll",
			"Assembly-UnityScript.dll",
			"Assembly-UnityScript-firstpass.dll",
			"bindata.dll",
			"LogUtils.dll",
			"Pathfinding.ClipperLib.dll",
			"Pathfinding.Poly2Tri.dll",
			"Photon3Unity3D.dll"
		};
		//Debug.Log("target: " + target.ToString());
		//Debug.Log("pathToBuiltProject: " + pathToBuiltProject);
		//Debug.Log("productName: " + PlayerSettings.productNam gne);
		//DLL在android工程中对应的位置 
		string srcfolder = @"C:\Users\moto2002\Desktop\mobahero.uc.v131812\assets\bin\Data\Managed";
		string dllfolder = @"C:\Users\moto2002\Desktop\dll";

		for (int i = 0; i < dlls.Length; i++) {
			if (File.Exists (srcfolder+@"\"+dlls[i])) {
				//先读取没有加密的dll  
				byte[] bytes = File.ReadAllBytes (srcfolder+@"\"+dlls[i]);
				//字节偏移 DLL就加密了。  
				bytes [0] -= 1;
				//在写到原本的位置上  
				File.WriteAllBytes (dllfolder+@"\"+dlls[i], bytes);
				Debug.Log ("Encrypt Assembly-CSharp.dll Success");
			} else {
				Debug.LogError (srcfolder+@"\"+dlls[i] + "  Not Found!!");
			}
		}
	}
}
