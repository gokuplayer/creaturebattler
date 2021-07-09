using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
	
	[Header("---Input setup---")]
	[Tooltip("Button to be used when player wants the selected unit to move or attack ")]
	public KeyCode Action = KeyCode.A;
	[Tooltip("Name of the axis to be used when player wants the selected unit to move or attack (leave empty if you want to use the KeyCode instead)")]
	public string inputAction;
	[Tooltip("Button to be used when player wants to enter the training menu")]
	public KeyCode Train = KeyCode.T;
	[Tooltip("Name of the axis to be used when player wants to enter the training menu (leave empty if you want to use the KeyCode instead)")]
	public string inputTrain;
	[Tooltip("Button to be used when player wants to enter the building menu")]
	public KeyCode Build = KeyCode.B;
	[Tooltip("Name of the axis to be used when player wants to enter the building menu (leave empty if you want to use the KeyCode instead)")]
	public string inputBuild;
	[Tooltip("Button to be used when player wants to go back from action/train/build modes")]
	public KeyCode Escape = KeyCode.Escape;
	[Tooltip("Name of the axis to be used when player wants to go back from action/train/build modes (leave empty if you want to use the KeyCode instead)")]
	public string inputEscape;
	
	//Reference to the gameManager object
	[HideInInspector] 
	public GameManager gameManager;
	
    // Start is called before the first frame update
    void Start()
    {
		//Get game manager reference
		try{
			gameManager=transform.GetComponent<GameManager>();
		}catch(System.Exception){
			throw new System.Exception("GameManager script could not be found from the InputManager script. Check if InputManager component is attached to the GameManager transform");
		}
		//Set up button listeners
		gameManager.uiManager.endTurnButton.onClick.AddListener(()=>gameManager.turnManager.EndTurn());
		gameManager.uiManager.ActionButton.onClick.AddListener(()=>gameManager.turnManager.currentPlayer.selectedUnit.Mode="action");
		gameManager.uiManager.BuildButton.onClick.AddListener(()=>gameManager.turnManager.currentPlayer.selectedUnit.Mode="build");
		gameManager.uiManager.BuildButton.onClick.AddListener(()=>gameManager.uiManager.SetBuild());
		gameManager.uiManager.TrainButton.onClick.AddListener(()=>gameManager.turnManager.currentPlayer.selectedUnit.Mode="train");
		gameManager.uiManager.TrainButton.onClick.AddListener(()=>gameManager.uiManager.SetTrain());
    }

    // Update is called once per frame
    void Update()
    {
		//Input loop
		try{
			//Escape event
			if( ( inputEscape!="" && Input.GetButtonDown(inputEscape) ) || Input.GetKeyDown(Escape) ){
				gameManager.turnManager.currentPlayer.selectedUnit.Mode="";
				gameManager.uiManager.SetBack();
			//Action event
			}else if( ( ( inputAction!="" && Input.GetButtonDown(inputAction) ) || Input.GetKeyDown(Action) ) && gameManager.turnManager.currentPlayer.selectedUnit.Mode=="" ){
				gameManager.turnManager.currentPlayer.selectedUnit.Mode="action";
				gameManager.uiManager.SetBack();
			//Train event
			}else if( ( ( inputTrain!="" && Input.GetButtonDown(inputTrain) ) || Input.GetKeyDown(Train) ) && gameManager.turnManager.currentPlayer.selectedUnit.Mode!="build" && gameManager.turnManager.currentPlayer.selectedUnit.Mode!="train" ){
				gameManager.turnManager.currentPlayer.selectedUnit.Mode="train";
				gameManager.uiManager.SetTrain();
			//Build event
			}else if( ( ( inputBuild!="" && Input.GetButtonDown(inputBuild) ) || Input.GetKeyDown(Build) ) && gameManager.turnManager.currentPlayer.selectedUnit.Mode!="train" && gameManager.turnManager.currentPlayer.selectedUnit.Mode!="build"){
				gameManager.turnManager.currentPlayer.selectedUnit.Mode="build";
				gameManager.uiManager.SetBuild();
			}else{
				//Train unit event
				if(gameManager.turnManager.currentPlayer.selectedUnit.Mode=="train"){
					foreach(Unit u in gameManager.turnManager.currentPlayer.selectedUnit.trainableUnits){
						if(u is PlayerUnitController){
							PlayerUnitController pu=(PlayerUnitController)u;
							if(Input.GetKeyDown(pu.Button)){
								gameManager.turnManager.currentPlayer.selectedUnit.pickedUnit=pu;
							}
						}
					}
				//Build unit event
				}else if(gameManager.turnManager.currentPlayer.selectedUnit.Mode=="build"){
					foreach(Unit u in gameManager.turnManager.currentPlayer.selectedUnit.buildableBuildings){
						if(u is PlayerUnitController){
							PlayerUnitController pu = (PlayerUnitController)u;
							if(Input.GetKeyDown(pu.Button)){
								gameManager.turnManager.currentPlayer.selectedUnit.pickedUnit=pu;
							}
						}
					}
				}
			}
		}catch(System.NullReferenceException){

		}
    }
	
	public void ClickedOnNeutralUnit(PointerEventData ptrED,NeutralUnitController unit){
		//Attack neutral unit event
		PlayerUnitController selectedUnit=gameManager.turnManager.currentPlayer.selectedUnit;
		if(selectedUnit.Mode=="action" || ptrED.button==PointerEventData.InputButton.Right){
			if(selectedUnit!=null){
				selectedUnit.Attack(unit);
				gameManager.uiManager.HighlightStep();
			}
		}
	}
	
	public void ClickedOnPlayerUnit(PointerEventData ptrED,PlayerUnitController unit){
		PlayerUnitController selectedUnit=gameManager.turnManager.currentPlayer.selectedUnit;
		if(unit.owner==gameManager.turnManager.currentPlayer){
			//Select player unit event
			if(selectedUnit!=null){
				selectedUnit.Mode="";
			}
			unit.owner.selectedUnit=unit;
			selectedUnit.Mode="";
			gameManager.uiManager.SetBack();
			gameManager.uiManager.HighlightStep();
		}else{
			//Attack enemy player unit event
			if(selectedUnit!=null && (selectedUnit.Mode=="action" || ptrED.button==PointerEventData.InputButton.Right)){
				selectedUnit.Attack(unit);
				gameManager.uiManager.HighlightStep();
			}
		}
	}
	
	public void ClickedOnTile(PointerEventData ptrED,Tile tile){
		PlayerUnitController selectedUnit=gameManager.turnManager.currentPlayer.selectedUnit;
		if(selectedUnit!=null){
			if(selectedUnit.Mode=="action" || ptrED.button==PointerEventData.InputButton.Right){
				//Move player unit event
				selectedUnit.Move(tile);
				gameManager.uiManager.HighlightStep();
			}else{
				//Build/Train player unit event
				if(selectedUnit.pickedUnit!=null){
					selectedUnit.TrainOrBuild(tile,selectedUnit.pickedUnit);
					selectedUnit.Mode="action";
					gameManager.uiManager.SetBack();
					gameManager.uiManager.HighlightStep();
				}
			}
		}
	}
	
}
