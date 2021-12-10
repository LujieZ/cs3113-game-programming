﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

//<summary>
//Game object, that creates maze and instantiates it in scene
//</summary>
public class MazeSpawner : MonoBehaviour {
	public enum MazeGenerationAlgorithm{
		PureRecursive,
		RecursiveTree,
		RandomTree,
		OldestTree,
		RecursiveDivision,
	}

	public MazeGenerationAlgorithm Algorithm = MazeGenerationAlgorithm.PureRecursive;
	public bool FullRandom = false;
	public int RandomSeed = 12345;
	public GameObject Floor = null;
	public GameObject Wall = null;
	public GameObject Pillar = null;
	public int Rows = 5;
	public int Columns = 5;
	public float CellWidth = 5;
	public float CellHeight = 5;
	public bool AddGaps = true;
	public GameObject GoalPrefab = null;

	private BasicMazeGenerator mMazeGenerator = null;

	public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate;

	public int GhostNum;

	private int GhostCount;

	void Start () {
		GhostCount = 0;
		if (!FullRandom) {
			Random.seed = RandomSeed;
		}
		switch (Algorithm) {
		case MazeGenerationAlgorithm.PureRecursive:
			mMazeGenerator = new RecursiveMazeGenerator (Rows, Columns);
			break;
		case MazeGenerationAlgorithm.RecursiveTree:
			mMazeGenerator = new RecursiveTreeMazeGenerator (Rows, Columns);
			break;
		case MazeGenerationAlgorithm.RandomTree:
			mMazeGenerator = new RandomTreeMazeGenerator (Rows, Columns);
			break;
		case MazeGenerationAlgorithm.OldestTree:
			mMazeGenerator = new OldestTreeMazeGenerator (Rows, Columns);
			break;
		case MazeGenerationAlgorithm.RecursiveDivision:
			mMazeGenerator = new DivisionMazeGenerator (Rows, Columns);
			break;
		}
		mMazeGenerator.GenerateMaze ();
		for (int row = 0; row < Rows; row++) {
			for(int column = 0; column < Columns; column++){
				float x = column*(CellWidth+(AddGaps?.2f:0));
				float z = row*(CellHeight+(AddGaps?.2f:0));
				MazeCell cell = mMazeGenerator.GetMazeCell(row,column);
				GameObject tmp;
				tmp = Instantiate(Floor,new Vector3(x,0,z), Quaternion.Euler(0,0,0)) as GameObject;
				tmp.transform.parent = transform;
				tmp = Instantiate(Floor,new Vector3(x,CellHeight,z), Quaternion.Euler(0,0,0)) as GameObject;
				tmp.transform.parent = transform;

				if(!(row==Rows-1 && column==Columns-1)){

					if(cell.WallRight){
						tmp = Instantiate(Wall,new Vector3(x+CellWidth/2,CellHeight/2,z)+Wall.transform.position,Quaternion.Euler(90,90,0)) as GameObject;// right
						tmp.transform.parent = transform;
					}
					if(cell.WallFront){
						tmp = Instantiate(Wall,new Vector3(x,CellHeight/2,z+CellHeight/2)+Wall.transform.position,Quaternion.Euler(90,0,0)) as GameObject;// front
						tmp.transform.parent = transform;
					}
					if(cell.WallLeft){
						tmp = Instantiate(Wall,new Vector3(x-CellWidth/2,CellHeight/2,z)+Wall.transform.position,Quaternion.Euler(90,270,0)) as GameObject;// left
						tmp.transform.parent = transform;
					}
					if(cell.WallBack){
						tmp = Instantiate(Wall,new Vector3(x,CellHeight/2,z-CellHeight/2)+Wall.transform.position,Quaternion.Euler(90,180,0)) as GameObject;// back
						tmp.transform.parent = transform;
					}
					if(cell.IsGoal && GoalPrefab != null && GhostCount<GhostNum){
						tmp = Instantiate(GoalPrefab,new Vector3(x,1,z), Quaternion.Euler(0,0,90)) as GameObject;
						tmp.transform.parent = transform;
						GhostCount++;
					}
				}
			}
		}



		if(Pillar != null){
			for (int row = 0; row < Rows+1; row++) {
				for (int column = 0; column < Columns+1; column++) {
					float x = column*(CellWidth+(AddGaps?.2f:0));
					float z = row*(CellHeight+(AddGaps?.2f:0));
					GameObject tmp = Instantiate(Pillar,new Vector3(x-CellWidth/2,0,z-CellHeight/2),Quaternion.identity) as GameObject;
					tmp.transform.parent = transform;
				}
			}
		}

		surfaces =  FindObjectsOfType<NavMeshSurface>();

        for (int i = 0; i < surfaces.Length; i++) 
        {
            surfaces [i].BuildNavMesh ();    
        }
		
	}
}
