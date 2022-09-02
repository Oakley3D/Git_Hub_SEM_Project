using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oakley_Image_View_Controller : MonoBehaviour
{
    public RectTransform image;
    public RectTransform min,max,img_min,img_max;
    
    public Transform parent,image_parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector3 l2w , w2l;
    
    // Update is called once per frame
    void Update()
    {
        float x  = Input.GetAxis("Horizontal");
        
        float y = Input.GetAxis("Vertical");

        Vector2 size = image.sizeDelta;
        
        Vector3 pos = image.localPosition;

        size = new Vector2( img_max.position.x - img_min.position.x , img_min.position.y - img_max.position.y);
        

        //l2w = image_parent.TransformPoint(image.localPosition);

        //w2l = parent.InverseTransformPoint(l2w);

        pos = image.position;

        pos += new Vector3(x,y );


        if ( pos.x + size.x  < max.position.x ) pos.x = max.position.x-size.x ;
        else if (pos.x > min.position.x )pos.x = min.position.x ;

       
        if (pos.y >  max.position.y ) pos.y = max.position.y ;
        else if (pos.y + size.y < min.position.y ) pos.y = min.position.y -size.y; 

        /*
        if ( pos.x + size.x  < max.localPosition.x ) pos.x = max.localPosition.x-size.x ;
        else if (pos.x > min.localPosition.x )pos.x = min.localPosition.x ;

       
        if (pos.y >  max.localPosition.y ) pos.y = max.localPosition.y ;
        else if (pos.y + size.y < min.localPosition.y ) pos.y = min.localPosition.y -size.y; 
       */

        world_pos= image.transform.TransformPoint(Vector3.zero );
       // Debug.Log(pos.y );
        Debug.Log("size "+  size);
        Debug.Log("max x "+  max.position.x);
         Debug.Log("min x "+  min.position.x);
         Debug.Log("image pos "+image.position);
        //image.localPosition = pos;
        image.position = pos;
        
    }
Vector3 world_pos ;
    void  OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(world_pos,Vector3.one*10);
        Gizmos.color = Color.red;
       // Gizmos.DrawWireCube(l2w,Vector3.one*10);
         Gizmos.color = Color.yellow;
        //Gizmos.DrawWireCube(l2w,Vector3.one*10);
    }
}
