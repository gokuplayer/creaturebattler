using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[Header("---Prefabs setup---")]
	[Tooltip("prefab to be spawned for trainable/buildable units and back button")]
	public GameObject buttonPrefab;
	[Tooltip("prefab of the popup alert that displays the damage done by this unit")]
	public Transform popUpPrefab;
	
	[Header("---Sliders setup---")]
	[Tooltip("displays how much time you have until end of turn")]
	public Transform Timer;
	
	[Header("---Panels setup---")]
	[Tooltip("main panel")]
	public Transform Mode;
	//[Tooltip("not used")]
	public Transform Action;
	[Tooltip("training panel")]
	public Transform Train;
	[Tooltip("building panel")]
	public Transform Build;
	[Tooltip("always visable panel")]
	public Transform HotbarPanel;
	
	[Header("---Text fields	setup---")]
	[Tooltip("displays current players resources")]
	public Text playerResource;
	[Tooltip("displays selected unit info")]
	public Text unitName;
	
	[Header("---Buttons setup---")]
	public Button endTurnButton;
	public Button ActionButton;
	public Button BuildButton;
	public Button TrainButton;
	
	[HideInInspector] 
	public GameManager gameManager;
	
    // Start is called before the first frame update
    void Start()
    {
		try{
			gameManager=transform.parent.GetComponent<GameManager>();
		}catch(System.Exception){
			throw new System.Exception("GameManager script could not be found from the UIManager script. Check if the uiManager object is parented to the GameManager gameObject.");
		}
    }

    // Update is called once per frame
    void Update()
    {
        //Slider timer step
		Timer.GetComponent<Slider>().value=gameManager.turnManager.remainingTime/gameManager.turnManager.turnTime;
		
		//Text selected unit info step
		if(gameManager.turnManager.currentPlayer.selectedUnit!=null)
			unitName.text=gameManager.turnManager.currentPlayer.selectedUnit.Name+" dmg:"+gameManager.turnManager.currentPlayer.selectedUnit.minDamage+"/"+gameManager.turnManager.currentPlayer.selectedUnit.maxDamage+" hp:"+gameManager.turnManager.currentPlayer.selectedUnit.HP;
		
		//Text resources step
		string textResources="";
		foreach(Utility.Resource r in gameManager.turnManager.currentPlayer.Resources){
			textResources+=r.toString();
		}
		playerResource.text="Player "+gameManager.turnManager.currentPlayer.playerID+"'s turn. Resources: "+textResources;
    }
	
	//Return ui to main unit menu
	public void SetBack(){
		if(HotbarPanel!=null && Build!=null){
			foreach(Transform t in Build){
				Destroy(t.gameObject);
			}
		}
		if(HotbarPanel!=null && Train!=null){
			foreach(Transform t in Train){
				Destroy(t.gameObject);
			}
		}
		SetPanel("mode");
	}

	//Enter training ui menu
	public void SetTrain(){
		if(gameManager.turnManager.currentPlayer.selectedUnit!=null){
			SetPanel("train");
			foreach(Unit u in gameManager.turnManager.currentPlayer.selectedUnit.trainableUnits){
				GameObject temp = Instantiate(buttonPrefab);
				temp.transform.SetParent(Train,false);
				string textResourcesCost = "";
				foreach(Utility.Resource r in u.resourcesCost){
					textResourcesCost+=r.name+":"+r.value+" ";
				}
				temp.transform.GetChild(0).GetComponent<Text>().text="Name:"+u.Name+" HP:"+u.HP+" Dmg:"+u.minDamage+"/"+u.maxDamage+" Att:"+u.attackRange+" Mvm:"+u.movementRange+textResourcesCost;
				temp.GetComponent<Button>().onClick.AddListener(()=>gameManager.turnManager.currentPlayer.selectedUnit.SetPickedUnit(u.Name.ToLower()));
			}
			GameObject backButton = Instantiate(buttonPrefab);
			backButton.transform.SetParent(Train,false);
			backButton.transform.GetChild(0).GetComponent<Text>().text="Back";
			backButton.GetComponent<Button>().onClick.AddListener(()=>SetBack());
			foreach(Transform t in Build){
				Destroy(t.gameObject);
			}
		}
	}
	
	//Enter building ui menu
	public void SetBuild(){
		if(gameManager.turnManager.currentPlayer.selectedUnit!=null){
			SetPanel("build");
			foreach(Unit u in gameManager.turnManager.currentPlayer.selectedUnit.buildableBuildings){
				GameObject temp = Instantiate(buttonPrefab);
				temp.transform.SetParent(Build,false);
				string textResourcesCost = "";
				foreach(Utility.Resource r in u.resourcesCost){
					textResourcesCost+=r.name+":"+r.value+" ";
				}
				temp.transform.GetChild(0).GetComponent<Text>().text="Name:"+u.Name+" HP:"+u.HP+" Dmg:"+u.minDamage+"/"+u.maxDamage+" Att:"+u.attackRange+" Mvm:"+u.movementRange+textResourcesCost;
				temp.GetComponent<Button>().onClick.AddListener(()=>gameManager.turnManager.currentPlayer.selectedUnit.SetPickedUnit(u.Name.ToLower()));
			}
			GameObject backButton = Instantiate(buttonPrefab);
			backButton.transform.SetParent(Build,false);
			backButton.transform.GetChild(0).GetComponent<Text>().text="Back";
			backButton.GetComponent<Button>().onClick.AddListener(()=>SetBack());
			foreach(Transform t in Train){
				Destroy(t.gameObject);
			}
		}
	}
	
	//Activate and deactivate ui panels
	void SetPanel(string Panel){
		Mode.gameObject.SetActive(false);
		Action.gameObject.SetActive(false);
		Train.gameObject.SetActive(false);
		Build.gameObject.SetActive(false);
		if(Panel=="mode"){
			Mode.gameObject.SetActive(true);
		}else if(Panel=="action"){
			Action.gameObject.SetActive(true);
		}else if(Panel=="train"){
			Train.gameObject.SetActive(true);
		}else if(Panel=="build"){
			Build.gameObject.SetActive(true);
		}
	}
	
	public void HighlightStep(){
		if(gameManager.useHighlightSystem && gameManager.turnManager.currentPlayer.selectedUnit!=null){
			Tile tileUnitIsStandingOn=null;
			foreach(Tile t in gameManager.mapManager.Tiles){
				//Destroy all highlights
				foreach(Transform child in t.transform){
					if(child.gameObject.tag=="highlights"){
						Destroy(child.gameObject);
					}
				}
				//Find tile selected unit is standing on
				if(t.transform.position==gameManager.turnManager.currentPlayer.selectedUnit.transform.position){
					tileUnitIsStandingOn=t;
				}
			}
			if(gameManager.turnManager.currentPlayer.selectedUnit.movesLeft>0){
				//Spawn movement range highlights
				List<Tile> checkedTiles = new List<Tile>();
				checkedTiles.Add(tileUnitIsStandingOn);
				SpawnMovementRange(tileUnitIsStandingOn,gameManager.turnManager.currentPlayer.selectedUnit.movementRange,new List<Tile>(),checkedTiles);
				//Spawn attack range highlights on neutral units
				Transform parent=null;
				foreach(Transform t in gameManager.mapManager.neutralUnitsContainer.transform){
					if(Mathf.Abs(t.position.x-gameManager.turnManager.currentPlayer.selectedUnit.transform.position.x)+Mathf.Abs(t.position.z-gameManager.turnManager.currentPlayer.selectedUnit.transform.position.z)<=gameManager.turnManager.currentPlayer.selectedUnit.attackRange && gameManager.turnManager.currentPlayer.selectedUnit.movesLeft>0){
						parent=null;
						foreach(Transform ti in gameManager.mapManager.transform){
							if(ti.gameObject.tag=="tile" && ti.position==t.position){
								parent=ti;
							}
						}
						Instantiate(gameManager.attackRangePrefab,t.position,Quaternion.identity,parent);
					}
				}
				//Spawn attack range highlights on enemy player units
				foreach(Player p in gameManager.Players){
					if(p!=gameManager.turnManager.currentPlayer){
						foreach(Transform t in p.unitManager){
							if(Mathf.Abs(t.position.x-gameManager.turnManager.currentPlayer.selectedUnit.transform.position.x)+Mathf.Abs(t.position.z-gameManager.turnManager.currentPlayer.selectedUnit.transform.position.z)<=gameManager.turnManager.currentPlayer.selectedUnit.attackRange && gameManager.turnManager.currentPlayer.selectedUnit.movesLeft>0){
								parent=null;
								foreach(Transform ti in gameManager.mapManager.transform){
									if(ti.gameObject.tag=="tile" && ti.position==t.position){
										parent=ti;
									}
								}
								Instantiate(gameManager.attackRangePrefab,t.position,Quaternion.identity,parent);
							}
						}
					}
				}
			}
			//Spawn selected unit highlights
			Transform parents=null;
			foreach(Transform ti in gameManager.mapManager.transform){
				if(ti.gameObject.tag=="tile" && ti.position==gameManager.turnManager.currentPlayer.selectedUnit.transform.position){
					parents=ti;
				}
			}
			Instantiate(gameManager.selectedUnitPrefab,gameManager.turnManager.currentPlayer.selectedUnit.transform.position,Quaternion.identity,parents);
		}
	}
	
	public void SpawnMovementRange(Tile root, int depth,List<Tile> markedTiles,List<Tile> checkedTiles){
		if(markedTiles.Contains(root)==false){
			if(root.IsTileEmpty("none")){
				bool enemyInAttackRange=false;
				bool enemyOnTile=false;
				foreach(Player p in gameManager.Players){
					if(gameManager.turnManager.currentPlayer!=p){
						foreach(Transform u in p.unitManager){
							if(u.GetComponent<PlayerUnitController>()!=null && Mathf.Abs(root.transform.position.x-u.position.x)+Mathf.Abs(root.transform.position.z-u.position.z)<=u.GetComponent<PlayerUnitController>().attackRange){
								enemyInAttackRange=true;
							}
							if(u.position==root.transform.position){
								enemyOnTile=true;
							}
						}
					}
				}
				foreach(Transform u in gameManager.mapManager.neutralUnitsContainer){
					if(u.GetComponent<NeutralUnitController>()!=null && Mathf.Abs(root.transform.position.x-u.position.x)+Mathf.Abs(root.transform.position.z-u.position.z)<=u.GetComponent<NeutralUnitController>().attackRange){
						enemyInAttackRange=true;
					}
					if(u.position==root.transform.position){
						enemyOnTile=true;
					}
				}
				if(enemyOnTile==false){
					if(enemyInAttackRange){
						Instantiate(gameManager.movementDangerPrefab,root.transform.position,Quaternion.identity,root.transform);
					}else{
						Instantiate(gameManager.movementSafePrefab,root.transform.position,Quaternion.identity,root.transform);
					}
				}
				
			}
			markedTiles.Add(root);
		}
		if(depth>0){
			foreach(Tile adjacent in root.adjacentTiles){
				if(checkedTiles.Contains(adjacent)==false && markedTiles.Contains(adjacent)==false){
					checkedTiles.Add(adjacent);
					if(adjacent.IsTileEmpty("none")){
						SpawnMovementRange(adjacent,depth-1,markedTiles,checkedTiles);
					}
				}
			}
		}else{
			return;
		}
	}
	
}
