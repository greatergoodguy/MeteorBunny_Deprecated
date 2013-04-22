using UnityEngine;
using System.Collections;

public class BGAdjuster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Transform bg1 = transform.Find("1 SpaceBG");
		Transform bg2 = transform.Find("2 SpaceTransitionBG");
		Transform bg3 = transform.Find("3 AtmosphereBG");
		Transform bg4 = transform.Find("4 AtmosphereTransitionBG");
		Transform bg5 = transform.Find("5 SkyBG");
		
		float bg1_Min = bg1.GetComponent<MeshRenderer>().bounds.min.y;
		float bg1_Max = bg1.GetComponent<MeshRenderer>().bounds.max.y;
		float bg2_Min = bg2.GetComponent<MeshRenderer>().bounds.min.y;
		float bg2_Max = bg2.GetComponent<MeshRenderer>().bounds.max.y;
		
		float bg1_Height = bg1.GetComponent<MeshRenderer>().bounds.size.y;
		float bg2_Height = bg2.GetComponent<MeshRenderer>().bounds.size.y;
		
		float bg1_halfHeight = bg1.GetComponent<MeshRenderer>().bounds.extents.y;
		float bg2_halfHeight = bg2.GetComponent<MeshRenderer>().bounds.extents.y;
		float bg3_halfHeight = bg3.GetComponent<MeshRenderer>().bounds.extents.y;
		float bg4_halfHeight = bg4.GetComponent<MeshRenderer>().bounds.extents.y;
		float bg5_halfHeight = bg5.GetComponent<MeshRenderer>().bounds.extents.y;
		
		setVectorY(bg2, bg1.position.y - (bg1_halfHeight + bg2_halfHeight));
		setVectorY(bg3, bg2.position.y - (bg2_halfHeight + bg3_halfHeight));
		setVectorY(bg4, bg3.position.y - (bg3_halfHeight + bg4_halfHeight));
		setVectorY(bg5, bg4.position.y - (bg4_halfHeight + bg5_halfHeight));
		
		//Debug.Log ("bg2.position: " + bg2.position.y);
		//Debug.Log ("bg3.position: " + bg3.position.y);
		//Debug.Log ("bg4.position: " + bg4.position.y);
		//Debug.Log ("bg5.position: " + bg5.position.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void setVectorY(Transform transformToModify, float y_value){
		Vector3 temp = transformToModify.position;
		temp.y = y_value;
		transformToModify.position = temp;
	}
}
