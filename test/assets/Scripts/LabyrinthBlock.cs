using UnityEngine;
using System.Collections;

public class LabyrinthBlock{
	public int startIndexX;		//Wo gestartet wird
	public int startIndexZ;
	public int width;			//Wie breit die Map ist
	public int length;			//die höhe der map
	//public GameObject mapObjekte;	//z.B Benzinkanister
		
	//Konstructor
	public LabyrinthBlock(int startIndexX, int startIndexZ, int width, int length){
        this.startIndexX = startIndexX;
        this.startIndexZ = startIndexZ;
        this.width = width;
        this.length = length;
	}
}
