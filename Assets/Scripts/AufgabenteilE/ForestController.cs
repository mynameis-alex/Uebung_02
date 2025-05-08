using System;
using UnityEngine;

public class ForestController : MonoBehaviour
{
    //Forest (current gameObject) containing all trees
    private GameObject[] Trees;

    private GameObject targetTree;

    public GameObject sparrow;
    private SparrowControllerE sparrowController;

    void Start() {
      
      sparrowController = sparrow.GetComponent<SparrowControllerE>();

      Trees = new GameObject[transform.childCount];
        
      //save all child objects
      for (int i = 0; i < transform.childCount; i++) {
        Trees[i] = transform.GetChild(i).gameObject;
      }

      //let all trees grow with different speeds and with different size-limits
      for (int i = 0; i < Trees.Length; i++) {
        //random speed and size
        float speed = new System.Random().Next(5, 10) / 500.0f; //second parameter is exclusive
        float size = new System.Random().Next(5, 16);
        Trees[i].GetComponent<TreeControllerE>().startGrowing(speed, size);
      }


    }

    void Update() {
        
      GameObject newTargetTree = getTargetTree();

      //select a target tree and tell sphere to move to it
      //only if there is no target tree or if target tree changed
      if (targetTree == null || targetTree != newTargetTree) {
        targetTree = newTargetTree;
        sparrowController.setTargetTree(targetTree);
      }

    }

    GameObject getTargetTree() {
      
      //go through all trees and check which is the highest
      int highestTreeIndex = 0;
      Boolean anyActive = false;

      for (int i = 0; i < Trees.Length; i++) {

        if (Trees[i].activeSelf) {
          anyActive = true;
        }

        if (
          //either tree must be active and higher
          (
            Trees[i].activeSelf == true &&
            Trees[i].transform.localScale.y > Trees[highestTreeIndex].transform.localScale.y
          ) ||
          //or current highest tree is not active anymore
          Trees[highestTreeIndex].activeSelf == false
          ) {
          highestTreeIndex = i;
          
        }
      }
      
      //if first is selected and it is not active anymore -> no tree active anymore and therefore return zero
      //otherwise either the index is different or tree is active and therefore return the tree object
      return anyActive ? Trees[highestTreeIndex] : null;

    }



    /*

      TO DO

      - fix trees not growing (at least not visibly)
      + adjust grow-rate cause might be too slow

      - detect correct tree (ignore deactivated trees!)

    */




}