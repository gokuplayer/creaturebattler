using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
	[Tooltip("time in seconds that a player has to finish his/her turn")]
	public float turnTime = 60f;
	
	//turn counter(resets back to 1 when it gets biger then the amount of players in game)
	[HideInInspector] 
	public int playerTurn;
	//reference to the player whose turn it is
	[HideInInspector] 
	public Player currentPlayer;
	//time left until end of turn
	[HideInInspector] 
	public float remainingTime;
	
	[HideInInspector] 
	public GameManager gameManager;
	
    // Start is called before the first frame update
    void Start()
    {
		try{
			gameManager=transform.parent.GetComponent<GameManager>();
		}catch(System.Exception){
			throw new System.Exception("GameManager script could not be found from the TurnManager script. Check if the turnManager object is parented to the GameManager gameObject.");
		}
		//Setup turn counter and timer
		remainingTime=turnTime;
		playerTurn=1;
    }

    // Update is called once per frame
    void Update()
    {
		//Step time system
		if(remainingTime-Time.deltaTime<=0f){
			EndTurn();
		}else{
			remainingTime-=Time.deltaTime;
		}
		
		//Set current player
        foreach(Player t in gameManager.Players){
			if(t.playerID==playerTurn && currentPlayer!=t){
				currentPlayer=t;
				gameManager.uiManager.HighlightStep();
			}
		}
    }
	
	public void EndTurn(){
		//Turn counter control
		bool skip;
		do{
			playerTurn++;
			skip=true;
			foreach(Player p in gameManager.Players){
				if(p.playerID==playerTurn){
					skip=false;
				}
			}
		}while(skip==true && gameManager.numberOfPlayers>=playerTurn);
		if(gameManager.numberOfPlayers<playerTurn){
			playerTurn=1;
			
			//Neutral units turn control
			List<Transform> neutrals = new List<Transform>();
			foreach(Transform u in gameManager.mapManager.neutralUnitsContainer.transform){
				neutrals.Add(u);
			}
			foreach(Transform u in neutrals){
				NeutralUnitController Unit=u.GetComponent<NeutralUnitController>();
				foreach(Utility.Resource r in Unit.Resources){
					r.value++;
				}
				Unit.movesLeft=Unit.maxMoves;
				Unit.AI();
			}
			
			//Resources turn control
			foreach(Transform t in gameManager.mapManager.transform){
				if(t.GetComponent<ResourceSpawner>()!=null){
					t.GetComponent<ResourceSpawner>().Spawn();
				}
			}
			
			//Player resource income
			foreach(Player t in gameManager.Players){
				foreach(Transform tr in t.unitManager){
					foreach(Utility.Resource r in t.Resources){
						foreach(Utility.Resource re in tr.GetComponent<PlayerUnitController>().resourcesIncome){
							if(r.name==re.name){
								r.value+=re.value;
							}
						}
					}
				}
			}
		}
		skip=true;
		foreach(Player p in gameManager.Players){
			if(p.playerID==playerTurn){
				skip=false;
			}
		}
		
		if(skip==true){
			do{
				playerTurn++;
				skip=true;
				foreach(Player p in gameManager.Players){
					if(p.playerID==playerTurn){
						skip=false;
					}
				}
			}while(skip==true && gameManager.numberOfPlayers>=playerTurn);
		}		

		//Player units turn control
		foreach(Player t in gameManager.Players){
			foreach(Transform tr in t.unitManager){
				PlayerUnitController Unit=tr.GetComponent<PlayerUnitController>();
				Unit.movesLeft=Unit.maxMoves;
				Unit.Mode="";
				gameManager.uiManager.SetBack();
			}
			//Resource gain
			if(t==currentPlayer){
				Utility.Resource.Modify(t.Resources,t.resourcesIncome,1);
			}
		}
		
		//Reset turn timer
		remainingTime=turnTime;
	}
}
