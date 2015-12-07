using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;


public enum Files
{
	BlocksModule
	
};

public class ISSCDIO : MonoBehaviour
{
	public static string SavaAllModulesAsJsonString (ISSCBGrid grid)
	{
	
		int[] tmpData = grid.GetRawData ();
	
		JsonData json = new JsonData ();
		/**/JsonData size = new JsonData();
		/**/JsonData blocks = new JsonData();
		ISSCBlockVector bv = grid.gridSize;
		size["x"] = bv.x.ToString();
		size["y"] = bv.y.ToString();
		size["z"] = bv.z.ToString();
		json["Size"] = size;
	
		for (int i = 0; i < tmpData.Length; i++) {
			blocks [i.ToString()] = tmpData [i];
		}
		json["Blocks"] = blocks;
		string str = json.ToJson ();
		return str;
//		Debug.Log ("Save Data As Json Succeed!");
	}
	
	public static void SaveDataIntoFile (string DataPath, string FileName,string text,string suffixName)
	{
		File.WriteAllText(DataPath+"/"+FileName+"."+suffixName,text);
	}
	
	public static JsonData LoadFileAsJson(string DataPath,string FileName){
	
		JsonData json = JsonMapper.ToObject(File.ReadAllText(DataPath+"/"+FileName));
		return json;
	}
	
	public static ISSCBGrid LoadJsonAsGrid(JsonData json){
		int vectorX,vectorY,vectorZ;
		vectorX = int.Parse(json["Size"]["x"].ToString());
		vectorY = int.Parse(json["Size"]["y"].ToString());
		vectorZ = int.Parse(json["Size"]["z"].ToString());
		ISSCBlockVector size = new ISSCBlockVector(vectorX,vectorY,vectorZ);
		int centerBlock = 2;
		ISSCBGridDescriber describ = new ISSCBGridDescriber();
		describ.centerBlock = centerBlock;
		describ.size = size;
		ISSCBGrid grid = new ISSCBGrid(describ);
		for(int i =0 ;i< grid.GetRawData().Length;i++){
			grid.SetBlock(grid.DecodeIndex(i),int.Parse(json["Blocks"][i.ToString()].ToString()));//?
		}
		return grid;
	}
	
	public static ISSCBGrid LoadFileToGrid(string DataPath,string FileName){
		return LoadJsonAsGrid(LoadFileAsJson(DataPath,FileName));
	}
	
	public static string GetDataPath (string[] dirs)
	{
		string tmpStr ;
	
		string appDir = Application.dataPath;
//		string[] dirs = new string[2];
//		dirs[0] = "Resources";
//		dirs[1] = "SaveData";
		
		for(int i = 0 ; i < dirs.Length ; i++){
		 	tmpStr = System.IO.Path.Combine(appDir,dirs[i]);
		 	System.IO.Directory.CreateDirectory(tmpStr);
		 	appDir += "/" + dirs[i];
		}
		
		return appDir;
		
	}

//	public static string GetFileName (Files f)
//	{
//	string str;
//	
//	switch(f){
//	case Files.BlocksModule: 
//	string 
//	break;
//	default : return ""; break;
//	}
//	
//	}
	
	
	
	
}
