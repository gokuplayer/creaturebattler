using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
	[Header("---Resource spawning setup---")]
	[Tooltip("minimal time between resources spawning")]
	public int minSpawnTime = 1;
	[Tooltip("maximum time between resources spawning")]
	public int maxSpawnTime = 10;
	[Tooltip("distance from spawner where resources can be spawned")]
	public int spawnRange = 2;
	[Tooltip("resource prefab to be spawned")]
	public Transform resourcePrefab;
	
	[HideInInspector] 
	public GameManager gameManager;
	[HideInInspector] 
	public int countDown;
	
    // Start is called before the first frame update
    void Start()
    {
		try{
			gameManager=GameObject.Find("GameManager").transform.GetComponent<GameManager>();
		}catch(System.Exception){
			throw new System.Exception("GameManager script could not be found from the ResourceSpawner script. Check if the GameManager gameObject exist in the scene");
		}
		countDown=Random.Range(minSpawnTime,maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {		
        
    }
	
	public void Spawn(){
		//counter step
		if(countDown==0){
			List<Transform> tilesInRange=new List<Transform>();
			//check for empty tiles in range
			foreach(Transform t in gameManager.mapManager.transform){
				if(t.GetComponent<Tile>()!=null){
					if(Mathf.Abs(t.position.x-transform.position.x)+Mathf.Abs(t.position.z-transform.position.z)<spawnRange && t.GetComponent<Tile>().IsTileEmpty("none") && t.position!=transform.position){
						tilesInRange.Add(t);
					}
				}
			}
			//spawn random empty tile in range
			if(tilesInRange.Count>0){
				Transform pickedTile=tilesInRange[Random.Range(0,tilesInRange.Count)];
				Instantiate(resourcePrefab,pickedTile.position,Quaternion.identity,gameManager.mapManager.transform);
				countDown=Random.Range(minSpawnTime,maxSpawnTime);
			}
		}else{
			countDown--;
		}
	}
	
}
