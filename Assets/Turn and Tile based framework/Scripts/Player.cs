using System.Collections;
using System.Collections.Generic;
using UnityEngine;	

public class Player : MonoBehaviour
{
	[Header("Resources setup",order=1)]
	[Tooltip("List of resources names and amount of that resource that player will gain each turn")]
	public List<Utility.Resource> resourcesIncome = new List<Utility.Resource>();
	[Tooltip("List of resources names and value of that resource that are added to the player on game start")]
	public List<Utility.Resource> startingResources = new List<Utility.Resource>();
	
	[Tooltip("Unit that the player starts with (double click to edit)")]
	public Transform startingUnit;
	
	//Reference to current players resources
	[HideInInspector]
	public List<Utility.Resource> Resources = new List<Utility.Resource>();
	//Players color
	[HideInInspector] 
	public Color playerColor;
	//Reference to unitManager
	[HideInInspector] 
	public Transform unitManager;
	//Unique player number
	[HideInInspector] 
	public int playerID;
	//Reference to the current selected unit of this player
	[HideInInspector] 
	public PlayerUnitController selectedUnit;
	//Reference to the game manager
	[HideInInspector] 
	public GameManager gameManager;
	
    // Start is called before the first frame update
    void Start()
    {
		try{
			gameManager=transform.parent.parent.GetComponent<GameManager>();
		}catch(System.Exception){
			throw new System.Exception("GameManager script could not be found from the Player script. Check if the player object is parented to the PlayerContainer transform, that is parented to the GameManager");
		}
		unitManager=transform.Find("UnitManager");
		
		//Init resources
		Utility.Resource.Modify(Resources,startingResources,1);
		//Init units
		Transform temp = Instantiate(startingUnit,transform.position,Quaternion.identity,unitManager);
		temp.GetComponent<Unit>().movesLeft=temp.GetComponent<Unit>().maxMoves;
		if(playerID!=1)
			temp.LookAt(transform.forward*-1);
		selectedUnit=temp.GetComponent<PlayerUnitController>();
		temp.GetComponent<PlayerUnitController>().unitColor=playerColor;
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy if no more units
		List<PlayerUnitController> units = new List<PlayerUnitController>();
		foreach(Transform t in unitManager){
			if(t.GetComponent<PlayerUnitController>()!=null){
				units.Add(t.GetComponent<PlayerUnitController>());
			}
		}
		if(units.Count==0){
			gameManager.Players.Remove(this);
			Debug.Log("Player " + playerID + "was defeated!");
			if(gameManager.Players.Count==1){
				Debug.Log("Player " + gameManager.Players[0].playerID + " won!");
				Application.Quit();
			}
			Destroy(gameObject);
		}
    }
}
