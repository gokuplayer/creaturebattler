using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility{
	
	[System.Serializable]
	public class Resource 
	{
		public string name;
		public int value;
		
		public string toString(){
			return name+value;
		}
		
		public static bool CompareToCost(List<Resource> target,List<Resource> cost){
			bool hasEnoughResources=true;
			foreach(Utility.Resource t in target){
				bool hasEnoughResource=true;
				foreach(Utility.Resource c in cost){
					if(t.name==c.name && t.value<c.value){
						hasEnoughResource=false;
					}
				}
				if(hasEnoughResource==false){
					hasEnoughResources=false;
				}
			}
			return hasEnoughResources;
		}
		
		public static void Modify(List<Resource> target,List<Resource> modification, int modifier){
			foreach(Resource m in modification){
				bool modified = false;
				foreach(Resource t in target){
					if(t.name==m.name){
						if(t.value+m.value*modifier>=0){
							t.value=t.value+m.value*modifier;
							modified=true;
						}else{
							Debug.LogError("You are trying to reduce resources to a negative number!");
							modified=true;
						}
					}
				}
				if(modified==false){
					target.Add(m);
				}
			}
		}

		public static List<Unit> FindUnitsInCostRange(List<Unit> units, List<Resource> resources){
			List<Unit> unitsInCostRange = new List<Unit>();
			foreach(Unit u in units){
				bool hasEnoughResources=true;
				foreach(Utility.Resource re in u.resourcesCost){
					bool hasEnoughResource=false;
					foreach(Utility.Resource r in resources){
						if(re.name==r.name && re.value<=r.value){
							hasEnoughResource=true;
						}
					}
					if(!hasEnoughResource){
						hasEnoughResources=false;
					}
				}
				if(hasEnoughResources){
					unitsInCostRange.Add(u);
				}
			}
			return unitsInCostRange;
		}
		
		new public string ToString(){
			return this.name+":"+this.value;
		}
		
		public static string ResourceListToString(List<Resource> resource){
			string resourceListString="";
				foreach(Utility.Resource r in resource){
					resourceListString+=r.ToString();
				}
			return resourceListString;
		}
		
	}	
	
	public class Pathfinding
	{
		public static int FindTargetScore(Tile start, Transform target, string skipType){
			List<Tile> openTiles = new List<Tile>();
			List<Tile> closedTiles = new List<Tile>();
			start.startScore=0;
			start.endScore=(int)Mathf.Abs(target.transform.position.x-start.transform.position.x)+(int)Mathf.Abs(target.transform.position.z-start.transform.position.z);
			openTiles.Add(start);
			while(openTiles.Count>0){
				Tile bestScoredTile=null;
				foreach(Tile t in openTiles){
					if(bestScoredTile==null || bestScoredTile.startScore+bestScoredTile.endScore>t.startScore+t.endScore){
						bestScoredTile=t;
					}
				}
				Tile currentTile=bestScoredTile;
				openTiles.Remove(currentTile);
				closedTiles.Add(currentTile);
				if(currentTile.transform.position==target.position){
					return currentTile.startScore;
				}else{
					foreach(Tile adjacent in currentTile.adjacentTiles){
						if(adjacent.IsTileEmpty(skipType)==false || closedTiles.Contains(adjacent)){
							
						}else{
							if(currentTile.startScore+1<adjacent.startScore || openTiles.Contains(adjacent)==false){
								adjacent.startScore=currentTile.startScore+1;
								adjacent.endScore=(int)Mathf.Abs(target.transform.position.x-adjacent.transform.position.x)+(int)Mathf.Abs(target.transform.position.z-adjacent.transform.position.z);
								if(openTiles.Contains(adjacent)==false){
									openTiles.Add(adjacent);
								}
							}
						}
					}
				}
			}
			return 0;
					
		}
		
		public static PlayerUnitController FindClosestUnitInRange(int attackRange, Tile tileUnitIsStandingOn){
			List<Tile> openTiles = new List<Tile>();
			List<Tile> closedTiles = new List<Tile>();
			foreach(Tile t in tileUnitIsStandingOn.adjacentTiles){
				openTiles.Add(t);
			}
			for(int i=0;i<attackRange;i++){
				foreach(Tile t in openTiles){
					foreach(Player p in t.mapManager.gameManager.Players){
						foreach(Transform u in p.unitManager){
							if(u.GetComponent<PlayerUnitController>()!=null && u.position==t.transform.position){
								return u.GetComponent<PlayerUnitController>();
							}
						}
					}
				}
				foreach(Tile t in openTiles){
					closedTiles.Add(t);
				}
				List<Tile> addToOpen = new List<Tile>();
				foreach(Tile t in openTiles){
					foreach(Tile at in t.adjacentTiles){
						addToOpen.Add(at);
					}
				}
				openTiles.Clear();
				foreach(Tile ao in addToOpen){
					if(closedTiles.Contains(ao)){
						
					}else{
						openTiles.Add(ao);
					}
				}
			}
			return null;
		}
	}
	
}