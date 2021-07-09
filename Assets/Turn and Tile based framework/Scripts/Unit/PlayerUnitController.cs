using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUnitController : Unit, IPointerClickHandler
{
    [Tooltip("hotkey used to build/train this unit when in appropriate mode")]
	public KeyCode Button = KeyCode.U;
	
	[HideInInspector]
	public Unit pickedUnit;
	[HideInInspector]
	public Player owner;
	[HideInInspector] 
	public string Mode;
	
	// Start is called before the first frame update
    new void Start()
    {
		base.Start();
		Mode="";
		owner=transform.parent.parent.GetComponent<Player>();
    }

    // Update is called once per frame
    new void Update()
    {
		base.Update();
    }
	
	//this unit is clicked
	public void OnPointerClick(PointerEventData ptrED){
		gameManager.inputManager.ClickedOnPlayerUnit(ptrED,this);
	}

	//picks a unit from buildable and trainable units lists to be placed on the map
	public void SetPickedUnit(string unitName){
		foreach(Unit u in trainableUnits){
			if(u.Name==unitName){
				pickedUnit=u;
			}
		}
		foreach(Unit u in buildableBuildings){
			if(u.Name==unitName){
				pickedUnit=u;
			}
		}
	}
}
