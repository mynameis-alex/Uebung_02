using System;
using UnityEngine;

public class ForestController : MonoBehaviour
{
    //Forest (current gameObject) containing all trees
    private GameObject[] Trees;

    private GameObject targetTree;

    public GameObject sphere;
    private SphereControllerE sphereController;

    void Start() {
      
      sphereController = sphere.GetComponent<SphereControllerE>();

      Trees = new GameObject[transform.childCount];
        
      //save all child objects
      for (int i = 0; i < transform.childCount; i++) {
        Trees[i] = transform.GetChild(i).gameObject;
      }

      //let all trees grow with different speeds and with different size-limits
      for (int i = 0; i < Trees.Length; i++) {
        //random speed and size
        float speed = new System.Random().Next(1, 10) / 1000.0f; //second parameter is exclusive
        float size = new System.Random().Next(5, 11);
        Trees[i].GetComponent<TreeControllerE>().startGrowing(i, speed, size);
      }


    }

    void Update() {
        
      GameObject newTargetTree = getTargetTree();

      //select a target tree and tell sphere to move to it
      //only if there is no target tree or if target tree changed
      if (targetTree == null || targetTree != newTargetTree) {
        targetTree = newTargetTree;
        Debug.Log("Neues Ziel: " + targetTree.name);
        sphereController.setTargetTree(targetTree);
      }

    }

    GameObject getTargetTree() {
      
      //go through all trees and check which is the highest
      int highestTreeIndex = 0;

      for (int i = 1; i < Trees.Length; i++) {
        if (
          Trees[i].activeSelf == true &&
          Trees[i].transform.localScale.y > Trees[highestTreeIndex].transform.localScale.y
          ) {
          highestTreeIndex = i;
        }
      }
      
      return Trees[highestTreeIndex];

    }



    /*

      TO DO

      - fix trees not growing (at least not visibly)
      + adjust grow-rate cause might be too slow

      - detect correct tree (ignore deactivated trees!)

      - rotate bird and sphere so that bird always follows sphere
      -> if bird is closer to tree than sphere, it seems as if sphere is following bird
        -> therefore, it looks as if the bird is flying backwards

    */




}