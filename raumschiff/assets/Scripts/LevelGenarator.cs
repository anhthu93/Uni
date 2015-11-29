using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenarator : MonoBehaviour
{	
	//Statische Daten zu den Blöcken
    private static int numberOfBlocks = 9;
    private static int blockLength = 20;
    private static int blockWidth = 20;

	//Array für die Blöcke
    //Das Object selber
	public GameObject[] blockGameObjects = new GameObject[numberOfBlocks];
    //Die Daten zu dem Object
    private LabyrinthBlock[] blocksInformations = new LabyrinthBlock[numberOfBlocks];

	/*
	//Wie viel % der Blöcke einen Menschen bzw Benzinkanister enthalten
	[Range(0,1)]  //0 = 0%   1 = 100%
	public float generateHuman = 0.5f;
	[Range(0,1)]
	public float generatePetrol = 0.5f;
	*/

	// Use this for initialization
	void Start(){
		GenerateLevel ();
	}

	//Funktion zur Erzeugung eines neuen Levels
    public void GenerateLevel()
    {	
        CreateBlocks();
        ChangeBlockPosition();
		DrawBlocks ();
    }

	private void ChangeBlockPosition (){
		for (int i = 0; i < blocksInformations.Length; i++) {
			int random = Random.Range(0, blocksInformations.Length);
			LabyrinthBlock temp = blocksInformations[i];
            blocksInformations[i] = blocksInformations[random];
            blocksInformations[random] = temp;
		}
	}

    //Positionen abspeichern
    private void CreateBlocks()
    {
        int i = 0;
        int posX = 0;
        int posZ = 0;
        for (int x = 0; x < Mathf.Sqrt(numberOfBlocks); x++)
        {
            for (int z = 0; z < Mathf.Sqrt(numberOfBlocks); z++)
            {
                blocksInformations[i] = new LabyrinthBlock(posX, posZ, blockWidth, blockLength);
                Debug.Log("posx"+posX);
                Debug.Log("startindex"+blocksInformations[i].startIndexX);
                posZ += blockLength;
                i++;
           }
           posX += blockWidth;
           posZ = 0;
       }
    }

	private void DrawBlocks(){
		for (int i = 0; i < blocksInformations.Length; i++) {
			//Blöcke zeichnen
			Instantiate (blockGameObjects[i], new Vector3 (blocksInformations[i].startIndexX,0, blocksInformations[i].startIndexZ), Quaternion.AngleAxis (270f, Vector3.right));
		}
	}

}
