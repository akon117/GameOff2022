using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;




public enum CanvasType
{
    Minigame1Canvas,
    Minigame2Canvas,
    Minigame3Canvas,
    ExplainCanvas
}




public class CanvasManager : Singleton<CanvasManager>
{
    public bool mini1 = false;
    public bool mini2 = false;
    public bool mini3 = false;

    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;

    protected override void Awake()
    {
        //Note: All UI Canvases must be active when the game starts for this to properly work   
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();

        // deactivate all the screens
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));

        //Switch to the MainMenu Canvas
        SwitchCanvas(CanvasType.ExplainCanvas);

    }


    //This function will be how we switch between Canvases
    //Essentially Give it a CanvasType and it will deactive the current canvas and switch to the given one
    public void SwitchCanvas(CanvasType _type)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else
        {
            Debug.LogWarning("The desired canvas was not found!");
        }




    }





}
