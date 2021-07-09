using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Unit : MonoBehaviour
{
	
	[Header("---General info setup---")]
	[Tooltip("units uniquie name")]
	public string Name = "unit";
	
	[Header("---Resources setup---")]
	[Tooltip("resources that this unit generates to its owner each turn")]
	public List<Utility.Resource> resourcesIncome = new List<Utility.Resource>();
	[Tooltip("resources that are awarded to the player who kills this unit")]
	public List<Utility.Resource> resourcesReward = new List<Utility.Resource>();
	[Tooltip("resources that a player must pay to build this unit")]
	public List<Utility.Resource> resourcesCost = new List<Utility.Resource>();
	
	[Header("---Movement setup---")]
	[Tooltip("how many times may this unit move each turn - test this")]
	public int maxMoves = 1;
	[Tooltip("distance that this unit can move in one move")]
	public int movementRange = 2;
	
	[Header("---Combat setup---")]
	[Tooltip("attack range of unit")]
	public int attackRange = 2;
	[Tooltip("starting and maximum health amount")]
	public int maxHP = 10;
	[Tooltip("minimal damage this unit does on attack")]
	public int minDamage = 1;
	[Tooltip("maximum damage this unit does on attack")]
	public int maxDamage = 3;
	
	[Header("---Building/training setup---")]
	[Tooltip("units that this unit can train")]
	public List<Unit> trainableUnits = new List<Unit>();
	[Tooltip("buildings that this unit can build")]
	public List<Unit> buildableBuildings = new List<Unit>();
	
	[Header("---UI setup---")]
	[Tooltip("hp bar that displays this units remaining health")]
	public UnityEngine.UI.Slider hpBar;
	[Tooltip("size of clickable collider of this unit")]
	public float colliderSize = 0.9f;
	public MeshRenderer Mesh;
	
	[HideInInspector]
	public Color unitColor;
	[HideInInspector] 
	public int HP;
	[HideInInspector] 
	public int movesLeft;
	[HideInInspector] 
	public int attacksLeft;
	[HideInInspector] 
	public GameManager gameManager;
	
    // Start is called before the first frame update
    public void Start()
    {
		try{
			gameManager=GameObject.Find("GameManager").transform.GetComponent<GameManager>();
		}catch(System.Exception){
			throw new System.Exception("GameManager script could not be found from the Unit script. Check if the GameManager gameObject exist in the scene");
		}
		//Init stats
		HP=maxHP;
		transform.GetComponent<BoxCollider>().size=colliderSize*Vector3.one;
		if(Mesh!=null){
			Mesh.materials[1].color=unitColor;
		}
	}

    // Update is called once per frame
    public void Update()
    {
		//Health bar step
		hpBar.value=(float)HP/(float)maxHP;
    }

	public bool Attack(Unit target){
		int Damage=Random.Range(minDamage,maxDamage);
		//attack the clicked unit
		Tile tileUnitIsStandingOn=null;
		foreach(Tile t in gameManager.mapManager.Tiles){
			if(t.transform.position==transform.position){
				tileUnitIsStandingOn=t;
			}
		}
		if(tileUnitIsStandingOn.IsInRange(target.transform,attackRange,"unit") && movesLeft>0){
			movesLeft--;
			if(target.HP>Damage){
				target.HP-=Damage;
			}else{
				//attacked unit is killed
				if(transform.GetComponent<PlayerUnitController>()!=null){
					Utility.Resource.Modify(transform.parent.parent.GetComponent<Player>().Resources,target.resourcesReward,1);
				}
				Destroy(target.gameObject);
			}
			Transform temp = Instantiate(gameManager.uiManager.popUpPrefab,target.transform.position+Vector3.up*3,gameManager.uiManager.popUpPrefab.rotation);
			temp.Find("Text").GetComponent<UnityEngine.UI.Text>().text=Damage.ToString();
			return true;
		}else{
			return false;
		}
	}
	
	//Move to the clicked tile
	public bool Move(Tile target){
		if(movesLeft>0){
			if(target.IsTileEmpty("resource")){
				Tile tileUnitIsStandingOn=null;
				foreach(Tile t in gameManager.mapManager.Tiles){
					if(t.transform.position==transform.position){
						tileUnitIsStandingOn=t;
					}
				}
				if(tileUnitIsStandingOn.IsInRange(target.transform,movementRange,"resource")){
					transform.position=target.transform.position;
					movesLeft--;
					return true;
				}else{
					return false;
				}
			}else{
				return false;
			}
		}else{
			return false;
		}
	}
	
	//Build or train a new unit
	public bool TrainOrBuild(Tile target,Unit pickedUnit){
		if(movesLeft>0){
			if(target.IsTileEmpty("resource")){
				if(Utility.Resource.CompareToCost(gameManager.turnManager.currentPlayer.Resources,pickedUnit.resourcesCost)){
					Tile tileUnitIsStandingOn=null;
					foreach(Tile t in gameManager.mapManager.Tiles){
						if(t.transform.position==transform.position){
							tileUnitIsStandingOn=t;
						}
					}
					bool targetIsInRange=false;
					foreach(Tile at in tileUnitIsStandingOn.adjacentTiles){
						if(at==target){
							targetIsInRange=true;
						}
					}
					if(targetIsInRange==true){
						//instantiate the unit
						Unit temp=Instantiate(pickedUnit,target.transform.position,Quaternion.identity,transform.parent);
						temp.unitColor=unitColor;
						if(gameManager.turnManager.currentPlayer.playerID!=1)
							temp.transform.LookAt(transform.forward*-1);
						movesLeft--;
						Utility.Resource.Modify(transform.parent.parent.GetComponent<Player>().Resources, temp.resourcesCost, -1);
						pickedUnit=null;
						gameManager.uiManager.SetBack();
						return true;
					}else{
						Debug.Log("Tile is out of range");
						return false;
					}
				}else{
					Debug.Log("You need "+Utility.Resource.ResourceListToString(pickedUnit.resourcesCost)+" resources to train/build that unit/building");
					return false;
				}
			}else{
				return false;
			}
		}else{
			return false;
		}
	}
}
