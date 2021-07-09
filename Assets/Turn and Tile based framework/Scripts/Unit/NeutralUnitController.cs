using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NeutralUnitController : Unit, IPointerClickHandler
{
	
	[Tooltip("resources that this unit starts with")]
	public List<Utility.Resource> startingResources = new List<Utility.Resource>();

	[HideInInspector]
	//keeps track of the resources this unit has
	public List<Utility.Resource> Resources = new List<Utility.Resource>();
	
    // Start is called before the first frame update
    void Awake()
    {
		base.Start();
		Resources=startingResources;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
	
	//this unit is clicked
	public void OnPointerClick(PointerEventData ptrED){
		gameManager.inputManager.ClickedOnNeutralUnit(ptrED,this);
	}
	
	//called at the end of every turn, the "thinking" that the unit does
	public void AI(){
		if(TryAttack()){
			
		}else if(TryTrainBuild()){
			
		}else{
			//Movement step
			List<Tile> emptyAdjacentTiles = new List<Tile>();
			foreach(Tile t in gameManager.mapManager.Tiles){
				if(Mathf.Abs(t.transform.position.x-transform.position.x)+Mathf.Abs(t.transform.position.z-transform.position.z)<=movementRange && t!=null){ 
					if(t.IsTileEmpty("none")){
						emptyAdjacentTiles.Add(t);
					}
				}
			}
			if(emptyAdjacentTiles.Count>0){
				Move(emptyAdjacentTiles[Random.Range(0,emptyAdjacentTiles.Count)]);
			}
		}
	}
	
	//cheks if unit can attack and calls inherited attack method
	bool TryAttack(){
		Tile tileUnitIsStandingOn=null;
		foreach(Tile t in gameManager.mapManager.Tiles){
			if(t.transform.position==transform.position){
				tileUnitIsStandingOn=t;
			}
		}
		
		PlayerUnitController closestUnitInRange = Utility.Pathfinding.FindClosestUnitInRange(attackRange,tileUnitIsStandingOn);
		if(closestUnitInRange==null){
			return false;
		}else{
			Attack(closestUnitInRange);
			return true;
		}
	}
	
	//checks if unit can train or build and calls inherited train or build method
	bool TryTrainBuild(){
		//check if you have enough resources to train or build a unit
		List<Unit> unitsInCostRange = Utility.Resource.FindUnitsInCostRange(trainableUnits,Resources);
		//find all tiles in range for you to build or train
		List<Tile> tilesInRange = new List<Tile>();
		foreach(Transform t in gameManager.mapManager.transform){
			if(Mathf.Abs(t.position.x-transform.position.x)+Mathf.Abs(t.position.z-transform.position.z)<=1){
				if(t.GetComponent<Tile>()!=null && t.GetComponent<Tile>().IsTileEmpty("resource")){
					tilesInRange.Add(t.GetComponent<Tile>());
				}
			}
		}
		//Pick a unit and spawn it
		if(unitsInCostRange.Count>0 && tilesInRange.Count>0){
			Unit temp=Instantiate(unitsInCostRange[Random.Range(0,unitsInCostRange.Count)],tilesInRange[Random.Range(0,tilesInRange.Count)].transform.position,Quaternion.identity,transform.parent);
			movesLeft--;
			Utility.Resource.Modify(Resources, temp.resourcesCost, -1);
			return true;
		}else{
			return false;
		}
		
	}	
}
