using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SimpleMenuItems
{
	[MenuItem("GameObject/Turn & Tile based framework/Game Manager", false, 1)]
    private static void CreateGameManager()
    {
		GameObject GameManager = (GameObject)Resources.Load("GameManager", typeof(GameObject));
		if(GameManager!=null){
			GameObject temp = GameObject.Instantiate(GameManager);
			temp.name="GameManager";
			Undo.RegisterCreatedObjectUndo(temp, "Create GameManager");
		}else{
			Debug.Log("GameManager missing from the Assets/Turn and Tile based framework/Resources folder");
		}
    }
	
	[MenuItem("GameObject/Turn & Tile based framework/Units/Player Units/Troop", false, 1)]
    private static void CreatePlayerTroopUnit()
    {
		GameObject PlayerTroopUnit = (GameObject)Resources.Load("Units/Player Units/Troop", typeof(GameObject));
		if(PlayerTroopUnit!=null){
			GameObject temp = GameObject.Instantiate(PlayerTroopUnit);
			temp.name="PlayerTroopUnit";
			Undo.RegisterCreatedObjectUndo(temp, "Create PlayerTroopUnit");
		}else{
			Debug.Log("PlayerTroopUnit missing from the Assets/Turn and Tile based framework/Resources/Player Units folder");
		}
    }
	
	[MenuItem("GameObject/Turn & Tile based framework/Units/Player Units/Building", false, 1)]
    private static void CreatePlayerBuildingUnit()
    {
		GameObject PlayerBuildingUnit = (GameObject)Resources.Load("Units/Player Units/Building", typeof(GameObject));
		if(PlayerBuildingUnit!=null){
			GameObject temp = GameObject.Instantiate(PlayerBuildingUnit);
			temp.name="PlayerBuildingUnit";
			Undo.RegisterCreatedObjectUndo(temp, "Create PlayerBuildingUnit");
		}else{
			Debug.Log("PlayerBuildingUnit missing from the Assets/Turn and Tile based framework/Resources/Player Units folder");
		}
    }
	
	[MenuItem("GameObject/Turn & Tile based framework/Units/Neutral Units/Troop", false, 1)]
    private static void CreateNeutralTroopUnit()
    {
		GameObject NeutralTroopUnit = (GameObject)Resources.Load("Units/Neutral Units/Troop", typeof(GameObject));
		if(NeutralTroopUnit!=null){
			GameObject temp = GameObject.Instantiate(NeutralTroopUnit);
			temp.name="NeutralTroopUnit";
			Undo.RegisterCreatedObjectUndo(temp, "Create NeutralTroopUnit");
		}else{
			Debug.Log("NeutralTroopUnit missing from the Assets/Turn and Tile based framework/Resources/Neutral Units folder");
		}
    }
	
	[MenuItem("GameObject/Turn & Tile based framework/Units/Neutral Units/Building", false, 1)]
    private static void CreateNeutralBuildingUnit()
    {
		GameObject NeutralBuildingUnit = (GameObject)Resources.Load("Units/Neutral Units/Building", typeof(GameObject));
		if(NeutralBuildingUnit!=null){
			GameObject temp = GameObject.Instantiate(NeutralBuildingUnit);
			temp.name="NeutralBuildingUnit";
			Undo.RegisterCreatedObjectUndo(temp, "Create NeutralBuildingUnit");
		}else{
			Debug.Log("NeutralBuildingUnit missing from the Assets/Turn and Tile based framework/Resources/Neutral Units folder");
		}
    }
	
	[MenuItem("GameObject/Turn & Tile based framework/Resource/Resource", false, 1)]
    private static void CreateResource()
    {
		GameObject Resource = (GameObject)Resources.Load("Resource/Resource", typeof(GameObject));
		if(Resource!=null){
			GameObject temp = GameObject.Instantiate(Resource);
			temp.name="Resource";
			Undo.RegisterCreatedObjectUndo(temp, "Create Resource");
		}else{
			Debug.Log("Resource missing from the Assets/Turn and Tile based framework/Resources/Resource folder");
		}
    }
	
	[MenuItem("GameObject/Turn & Tile based framework/Resource/ResourceSpawner", false, 1)]
    private static void CreateResourceSpawner()
    {
		GameObject ResourceSpawner = (GameObject)Resources.Load("Resource/ResourceSpawner", typeof(GameObject));
		if(ResourceSpawner!=null){
			GameObject temp = GameObject.Instantiate(ResourceSpawner);
			temp.name="ResourceSpawner";
			Undo.RegisterCreatedObjectUndo(temp, "Create ResourceSpawner");
		}else{
			Debug.Log("ResourceSpawner missing from the Assets/Turn and Tile based framework/Resources/Resource folder");
		}
    }
	
	[MenuItem("GameObject/Turn & Tile based framework/Map/PremadeMapGrid", false, 1)]
    private static void CreatePremadeMapGrid()
    {
		GameObject PremadeMapGrid = (GameObject)Resources.Load("Map/PremadeMapGrid", typeof(GameObject));
		if(PremadeMapGrid!=null){
			GameObject temp = GameObject.Instantiate(PremadeMapGrid);
			temp.name="PremadeMapGrid";
			Undo.RegisterCreatedObjectUndo(temp, "Create PremadeMapGrid");
		}else{
			Debug.Log("PremadeMapGrid missing from the Assets/Turn and Tile based framework/Resources/Map folder");
		}
    }
	
	[MenuItem("GameObject/Turn & Tile based framework/Map/PremadeMapHex", false, 1)]
    private static void CreatePremadeMapHex()
    {
		GameObject PremadeMapHex = (GameObject)Resources.Load("Map/PremadeMapHex", typeof(GameObject));
		if(PremadeMapHex!=null){
			GameObject temp = GameObject.Instantiate(PremadeMapHex);
			temp.name="PremadeMapHex";
			Undo.RegisterCreatedObjectUndo(temp, "Create PremadeMapHex");
		}else{
			Debug.Log("PremadeMapHex missing from the Assets/Turn and Tile based framework/Resources/Map folder");
		}
    }
	
	[MenuItem("GameObject/Turn & Tile based framework/Map/Tile", false, 1)]
    private static void CreateTile()
    {
		GameObject Tile = (GameObject)Resources.Load("Map/Tile", typeof(GameObject));
		if(Tile!=null){
			GameObject temp = GameObject.Instantiate(Tile);
			temp.name="Tile";
			Undo.RegisterCreatedObjectUndo(temp, "Create Tile");
		}else{
			Debug.Log("Tile missing from the Assets/Turn and Tile based framework/Resources/Map folder");
		}
    }
	
	[MenuItem("GameObject/Turn & Tile based framework/Map/HexTile", false, 1)]
    private static void CreateHexTile()
    {
		GameObject HexTile = (GameObject)Resources.Load("Map/HexTile", typeof(GameObject));
		if(HexTile!=null){
			GameObject temp = GameObject.Instantiate(HexTile);
			temp.name="HexTile";
			Undo.RegisterCreatedObjectUndo(temp, "Create HexTile");
		}else{
			Debug.Log("HexTile missing from the Assets/Turn and Tile based framework/Resources/Map folder");
		}
    }
	
}
