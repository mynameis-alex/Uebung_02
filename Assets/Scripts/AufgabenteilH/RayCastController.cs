using UnityEngine;


public class RayCastController : MonoBehaviour {

    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor;
    public LayerMask interactableLayerMask;
    private float maxRaycastDistance = 5f;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable currentSelection = null;

    //Bird (to set target)
    public GameObject bird;
    private SparrowControllerH birdController;



  void Start() {
    birdController = bird.GetComponent<SparrowControllerH>();
  }

  void Update() {

        if (rayInteractor != null) {

            RaycastHit hit;

            //generate ray (pos + fwd + length) and save in hit (if something is hitted), only care for certain layer
            if (Physics.Raycast(
                rayInteractor.transform.position,
                rayInteractor.transform.forward,
                out hit,
                maxRaycastDistance,
                interactableLayerMask
            )) {

                UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable =
                hit.collider.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();

                //check if selected object is an interactable and if it is a new (then change selected object)
                if (interactable != null && interactable != currentSelection) {
                    currentSelection = interactable;
                    birdController.setTargetTree(currentSelection.gameObject);
                    //Debug.Log("Ausgewählter Baum: " + interactable.gameObject.name);
                }
            }
           
        }
    }

}
