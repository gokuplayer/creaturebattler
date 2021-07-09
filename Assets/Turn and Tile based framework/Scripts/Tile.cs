using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
	[HideInInspector] 
	public List<Tile> adjacentTiles = new List<Tile>();
	[HideInInspector] 
	public MapManager mapManager;
	[HideInInspector] 
	public int startScore;
	[HideInInspector] 
	public int endScore;
	
    // Start is called before the first frame update
    void Awake()
    {
        mapManager=transform.parent.GetComponent<MapManager>();
		foreach(Tile t in mapManager.Tiles){
			float Offset=0f;
			if(mapManager.mapTileLayout==MapManager.tileLayout.Hex){
				Offset=0.5f;
			}
			if(Mathf.Abs(t.transform.position.x-transform.position.x)+Mathf.Abs(t.transform.position.z-transform.position.z)<=1+Offset && transform.position!=t.transform.position && adjacentTiles.Contains(t)==false){
				adjacentTiles.Add(t);
				t.adjacentTiles.Add(this);
			}
		}
    }
	
	void Start(){
		
	}
	
	public void OnPointerClick(PointerEventData ptrED){
		mapManager.gameManager.inputManager.ClickedOnTile(ptrED,this);
	}
	
	//checks if a tile is not occupied
	public bool IsTileEmpty(string skipType){
		bool tileEmpty = true;
		
		//check if a players unit is on that tile
		foreach(Transform t in transform.parent.parent.Find("PlayerContainer")){
			foreach(Transform u in t.Find("UnitManager")){
				if(u.position==transform.position){
					if(skipType=="unit"){
						
					}else{
						tileEmpty=false;
					}
				}
			}
		}
		
		//check if a neutral unit is on that tile
		foreach(Transform t in mapManager.neutralUnitsContainer){
			if(t.position==transform.position){
				if(skipType=="unit"){
					
				}else{
					tileEmpty=false;
				}
			}
		}
		
		//check if a resource is on that tile
		foreach(Transform t in mapManager.transform){
			if(t.GetComponent<ResourceSpawner>()!=null && t.position==transform.position){
				tileEmpty=false;
			}else if(t.GetComponent<Resource>()!=null && t.position==transform.position){
				if(skipType=="resource"){
					
				}else{
					tileEmpty=false;
				}
			}
		}
		return tileEmpty;
	}
	
	public bool IsInRange(Transform target,int range,string skipType){
		if(Utility.Pathfinding.FindTargetScore(this,target,skipType)<=range && Utility.Pathfinding.FindTargetScore(this,target,skipType)!=0)
			return true;
		else 
			return false;
	}
	
}
