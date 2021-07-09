using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
	public enum tileLayout { Grid, Hex };
	public tileLayout mapTileLayout = tileLayout.Grid;
	[Tooltip("Tile prefab used to populate the ground of the randomly generated map (double click on this to edit)")]
	public Tile tilePrefab;
	[Tooltip("Minimal number of tiles to spawn in one row")]
	public int minWidth = 5;
	[Tooltip("Maximum number of tiles to spawn in one row")]
	public int maxWidth = 10;
	[Tooltip("Maximum number of tiles to spawn in one column")]
	public int minHeight = 5;
	[Tooltip("Minimal number of tiles to spawn in one column")]
	public int maxHeight = 10;
	[Tooltip("Resources to be spawned on the map onstart")]
	public Transform[] resourcesPrefab;
	[Tooltip("minimal number of resources to be spawned on the map")]
	public int minResources = 1;
	[Tooltip("maximum number of resources to be spawned on the map")]
	public int maxResources = 3;
	[Tooltip("minimal distance to players units for neutral units to spawn at the start")]
	public int minPlayerToNeutralsDistance = 5;
	[Tooltip("minimal distance to players units for resources to spawn at the start")]
	public int minPlayerToResourceDistance = 3;
	[Tooltip("minimal number of neutral units to be spawned on the map")]
	public int minNeutrals = 1;
	[Tooltip("maximum number of neutral units resources to be spawned on the map")]
	public int maxNeutrals = 3;
	[Tooltip("neutral units to be spawned on the map onstart")]
	public Unit[] neutralUnits;
	[Tooltip("scales tiles down so they are apart a distance equal to double this value eg: if tilePadding is set to 0.1 tiles will be scaled down to 0.9 ")]
	public float tilePadding = 0.05f;
	[Tooltip("use this for premade maps only ")]
	public List<Transform> playerStartingPosition = new List<Transform>();
	[Tooltip("use this for premade maps only")]
	public Transform neutralUnitsContainer;
	
	[System.NonSerialized]
	//Map width calculated on start
	public int Width;
	[System.NonSerialized]
	//Map height calculated on start
	public int Height;
	[System.NonSerialized]
	//Reference to the gameManager object
	public GameManager gameManager;
	[System.NonSerialized]
	//List of tiles on map
	public List<Tile> Tiles = new List<Tile>();

    // Start is called before the first frame update
    void Awake()
    {
		//Get game manager reference
		try{
			gameManager=transform.parent.GetComponent<GameManager>();
		}catch(System.Exception){
			throw new System.Exception("GameManager script could not be found from the MapManager script. Check if MapManager object is parented to the gameManagers transform");
		}
		//Generate map
		if(gameManager.useRandomlyGeneratedMap){
			Width=Random.Range(minWidth,maxWidth);
			Height=Random.Range(minHeight,maxHeight);
			float jOffset=0f;
			float iOffset=1f;
			if(mapTileLayout==tileLayout.Hex){
				jOffset=0.5f;
				iOffset=(3/(2*Mathf.Sqrt(3)));
			}
			for(int i=0;i<Width;i++){
				for(int j=0;j<Height;j++){
					Tile temp=null;
					if(i%2==0){
						temp = Instantiate(tilePrefab,transform.position+new Vector3(i*iOffset,0,j),Quaternion.identity,transform);
					}else{
						temp = Instantiate(tilePrefab,transform.position+new Vector3(i*iOffset,0,j+jOffset),Quaternion.identity,transform);
					}
					temp.transform.localScale-=Vector3.one*tilePadding;
					Tiles.Add(temp);
				}
			}
			//Generate player starting positions
			List<Tile> tempTiles = new List<Tile>(Tiles);
			for(int i=0;i<gameManager.numberOfPlayers;i++){
				if(tempTiles.Count<1){
					throw new System.Exception("Map too small for that number of players");
				}
				Tile tempTile = tempTiles[Random.Range(0,tempTiles.Count)];
				playerStartingPosition.Add(new GameObject("PlayerStartingPosition").transform);
				playerStartingPosition[i].position=tempTile.transform.position;
				playerStartingPosition[i].parent=transform;
				tempTiles.Remove(tempTile);
				foreach(Tile t in tempTile.adjacentTiles){
					tempTiles.Remove(t);
					foreach(Tile ti in t.adjacentTiles){
						tempTiles.Remove(ti);
					}
				}
			}	
		}else{
			//Add all tiles to the internal tile list
			foreach(Transform t in transform){
				if(t.gameObject.tag=="tile" && t.GetComponent<Tile>()!=null){
					Tiles.Add(t.GetComponent<Tile>());
				}
			}
		}
		if(gameManager.useRandomlyGeneratedMap){
			//Initialise neutral units container
			neutralUnitsContainer=new GameObject("NeutralUnitsContainer").transform;
			neutralUnitsContainer.parent=transform;
		}
    }
	
	void Start(){
		//Generate resources
		if(gameManager.useRandomlyGeneratedResources && resourcesPrefab.Length>0){
			int Resources=Random.Range(minResources,maxResources);
			List<Tile> availableTiles=new List<Tile>();
			foreach(Tile t in Tiles){
				if(t.IsTileEmpty("none")){
					bool tileOutOfRange=true;
					foreach(Player p in gameManager.Players){
						if(Mathf.Abs(p.transform.position.x-t.transform.position.x)+Mathf.Abs(p.transform.position.z-t.transform.position.z)<minPlayerToResourceDistance){
							tileOutOfRange=false;
						}
					}
					if(tileOutOfRange){
						availableTiles.Add(t);
					}
				}
			}
			for(int i=0;i<Resources;i++){
				Instantiate(resourcesPrefab[Random.Range(0,resourcesPrefab.Length)],availableTiles[Random.Range(0,availableTiles.Count-1)].transform.position,Quaternion.identity,transform);
			}
		}
		
		//Generate neutral units
		if(gameManager.useRandomlyGeneratedNeutrals && neutralUnits.Length>0){
			int Neutrals=Random.Range(minNeutrals,maxNeutrals);
			List<Tile> availableTiles=new List<Tile>();
			foreach(Tile t in Tiles){
				if(t.IsTileEmpty("none")){
					bool tileOutOfRange=true;
					foreach(Player p in gameManager.Players){
						if(Mathf.Abs(p.transform.position.x-t.transform.position.x)+Mathf.Abs(p.transform.position.z-t.transform.position.z)<minPlayerToNeutralsDistance){
							tileOutOfRange=false;
						}
					}
					if(tileOutOfRange){
						availableTiles.Add(t);
					}
				}
			}
			for(int i=0;i<Neutrals;i++){
				if(availableTiles.Count>0){
					Instantiate(neutralUnits[Random.Range(0,neutralUnits.Length)],availableTiles[Random.Range(0,availableTiles.Count-1)].transform.position,Quaternion.identity,neutralUnitsContainer.transform);
				}
			}
		}
	}
}
