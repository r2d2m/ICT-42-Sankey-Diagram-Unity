using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



/*
 * Class Name :
 *   DragNode
 */
/*
 * Class Description :
 *   This class implements IDragHandler interface to obtain the function of monitoring
 *   the coordinates before and after the mouse drag. The position of the dragged node
 *   will be changed in the data storage by the methods in this class. The update method
 *   in the NodeShow class will continuously update the display of the nodebased on the 
 *   current data storage.
 */
public class DragNode : MonoBehaviour, IDragHandler
{
    //initialize the attribution of this class
    [SerializeField] RectTransform drag;
    public NodesStructure a;
    public float nodewidth;
     public float nodeheight;
    private GameObject nodeshow;

    //set the node
    public void setRectTransform(RectTransform rectTransform,GameObject nodeshow)
    {
        drag = rectTransform;
        this.nodeshow = nodeshow;
    }

    //set the width, and hight of the node
    public void setNodeStructure(NodesStructure node, float width, float hight)
    {
        a = node;
        nodewidth = width;
        nodeheight = hight;
    }

    //handle the process of drag node
    //showing drag the node
    public void OnDrag(PointerEventData eventData)
    {

        Vector2 result;
        Vector2 clickPosition = eventData.position;
        RectTransform thisRect = GetComponent<RectTransform>();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(thisRect.parent.GetComponent<RectTransform>(), clickPosition, GameObject.Find("Camera").GetComponent<Camera>(), out result);
        result += thisRect.sizeDelta / 2;

        drag.GetComponent<RectTransform>().localPosition = eventData.position;
        /*Debug.Log(a.name+" "+eventData);*/
        a.x0 = result.x-nodewidth;
         a.y0 = result.y-nodeheight;
        a.y1 = result.y;
        a.x1 = result.x;
        nodeshow.GetComponent<NodeShow>().dragFlag = true;
        nodeshow.GetComponent<NodeShow>().dragNode = this.name.Substring(5);
        Debug.Log(nodeshow.GetComponent<NodeShow>().dragNode);

    }
    
   
        
    
}
