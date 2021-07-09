using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class GameManager : MonoBehaviour
{
	[Header("Player setup",order=1)]
	[Tooltip("Number of players (The map that you are using has a limit that you must keep in mind)")]
	public int numberOfPlayers = 2;
	[Tooltip("List of colors to be assigned to the players")]
	public List<Color> playerColors = new List<Color>();
	[Tooltip("Player prefab to be instantiated (Double click on this to get more player options)")]
	public Player playerPrefab;

	[Header("Map setup",order=1)]
	[Tooltip("Check if you want to use the randomly generated map")]
	public bool useRandomlyGeneratedMap = true;
	[Tooltip("Check if you want your map to be randomly populated with resource objects")]
	public bool useRandomlyGeneratedResources = false;
	[Tooltip("Check if you want your map to be randomly populated with neutral units")]
	public bool useRandomlyGeneratedNeutrals = false;
	[Tooltip("Prefab of the premade map to use (Double click on this to edit)")]
	public MapManager premadeMapPrefab;
	[Tooltip("Prefab of the randomly generated map to use (Double click on this to get more map options)")]
	public MapManager randomlyGeneratedMapPrefab;
	
	[Header("Turn setup",order=1)]
	[Tooltip("Turn manager prefab to be instantiated")]
	public TurnManager turnManagerPrefab;
	
	[Header("Highlight setup",order=1)]
	[Tooltip("Check this if you want to use the highlight system( highlight system marks selected unit, safe and dangerous tiles you can move to, and enemies in attack range)")]
	public bool useHighlightSystem = true;
	[Tooltip("Prefab to be spawned at position of unit when it is selected")]
	public Transform selectedUnitPrefab;
	[Tooltip("Prefab to be spawned at position of tile that the selected unit can move to without being in range of enemy attacks")]
	public Transform movementSafePrefab;
	[Tooltip("Prefab to be spawned at position of tile that the selected unit can move to with being in range of enemy attacks")]
	public Transform movementDangerPrefab;
	[Tooltip("Prefab to be spawned at position of unit that the selected unit can attack")]
	public Transform attackRangePrefab;
	
	[Header("UI setup",order=1)]
	[Tooltip("UI manager prefab to be instantiated (Double click on this to edit)")]
	public UIManager uiManagerPrefab;
	
	
	//Reference to input manager
	[HideInInspector] 
	public InputManager inputManager;
	//Reference to map manager
	[HideInInspector] 
	public MapManager mapManager;
	//Reference to turn manager
	[HideInInspector] 
	public TurnManager turnManager;
	//Reference to ui manager
	[HideInInspector] 
	public UIManager uiManager;
	//Reference to player container 
	[HideInInspector] 
	public Transform playerContainer;
	//List of references to players
	[HideInInspector] 
	public List<Player> Players=new List<Player>();
	
    // Start is called before the first frame update
    void Awake()
    {	
		//Get input manager
			try{
				inputManager=transform.GetComponent<InputManager>();
			}catch(System.NullReferenceException){
				throw new System.Exception("InputManager script missinng from the game manager. Add the inputManager component to the game manager transform.");
			}
		//Initialise turn controller
			try{
				turnManager=Instantiate(turnManagerPrefab,transform);
			}catch(System.Exception ex){
				if(ex is System.NullReferenceException || ex is System.ArgumentException){
					throw new System.Exception("turnManager prefab missinng from the game manager. Add a turnManagerPrefab reference to the game managers inspector.");
				}else{
					throw ex;
				}
			}
		//Instantiate ui controller
		try{
			uiManager=Instantiate(uiManagerPrefab,transform);
		}catch(System.Exception){
			throw new System.Exception("uiManager prefab missinng from the game manager. Add a uiManagerPrefab reference to the game managers inspector");
		}
		
		//Initialise map controller
		if(useRandomlyGeneratedMap){
			try{
				mapManager=Instantiate(randomlyGeneratedMapPrefab,transform);
			}catch(System.Exception){
				throw new System.Exception("mapManager prefab missinng from the game manager. Add a mapManagerPrefab reference to the game managers inspector");
			}
		}else{
			try{
				mapManager=Instantiate(premadeMapPrefab,transform);
			}catch(System.Exception){
				throw new System.Exception("premadeMap prefab missinng from the game manager. Add a premadeMapPrefab reference to the game managers inspector");
			}
		}
		
		//Initialise players
		playerContainer=new GameObject("PlayerContainer").transform;
		playerContainer.parent=transform;
		try{
			for(int i=0;i<numberOfPlayers;i++){
				if(mapManager.playerStartingPosition.Count>=i){
					Players.Add(Instantiate(playerPrefab,mapManager.playerStartingPosition[i].position,Quaternion.identity,playerContainer));
					Players[i].playerID=i+1;
					Players[i].playerColor=playerColors[i];
				}else
					throw new System.Exception("mapManager does not contain "+i+" different playerStartingPosition transform. Reduce the number of players, or add more playerStartingPosition transform to the mapManagers inspector");
			}
		}catch(System.Exception){
			throw new System.Exception("player prefab missinng from the game manager. Add a playerPrefab reference to the game managers inspector");
		}
    }
}
