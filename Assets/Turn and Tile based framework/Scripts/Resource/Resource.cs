using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
	[Tooltip("list of resources that are awarded to the player who picks it up")]
	public List<Utility.Resource> Resources = new List<Utility.Resource>();
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //resource pickup step
		foreach(Player p in transform.parent.parent.GetComponent<GameManager>().Players){
			foreach(Transform t in p.unitManager){
				if(transform.position==t.transform.position){
					Utility.Resource.Modify(p.Resources,Resources,1);
					Destroy(gameObject);
				}
			}
		}
    }
}
