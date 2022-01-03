using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointManagerWindow : EditorWindow
{

    [MenuItem("Tools/Waypoint Editor")]
    public static void Open()
    {
        GetWindow<WaypointManagerWindow>();
    }

    public Transform waypointRoot;

    public int spawnable;

    public string spawnwp;
    public string wp;

    public string old_name;
    public string new_name;
   
   private void OnGUI()
   {
       SerializedObject obj = new SerializedObject(this);

       EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));

       if(waypointRoot == null)
       {
           EditorGUILayout.HelpBox("Root transform must be selected.  Please assign a root transform.", MessageType.Warning);

       }

       else
       {
           EditorGUILayout.BeginVertical("box");
           DrawButtons();
           EditorGUILayout.EndVertical();
       }

        obj.ApplyModifiedProperties();

   } 

      void DrawButtons()
   { 
     spawnwp ="Waypoint_SP ";
     wp = "Waypoint ";


              if(GUILayout.Button("Create Spawnable Waypoint"))
       {
           spawnable = 1;
           CreateWaypoint(spawnable);
       }

       if (Selection.activeGameObject != null  && Selection.activeGameObject.GetComponent<Waypoint>())
       {
           if(GUILayout.Button("Add Branch Waypoint"))
           {
               CreateBranch();
           }

GUILayout.Space(20);

                    if(GUILayout.Button("Create Spawnable Waypoint After"))
           {
               spawnable = 1;
               CreateWaypointAfter(spawnable);
           }

             if(GUILayout.Button("Create Waypoint After"))
           {
               spawnable = 0;
               CreateWaypointAfter(spawnable);
           }

GUILayout.Space(20);

             if(GUILayout.Button("Remove Waypoint"))
           {
               RemoveWaypoint();
           }

GUILayout.Space(20);
           
       if(GUILayout.Button("Create Waypoint"))
       {
           spawnable = 0;
           CreateWaypoint(spawnable);
       }

GUILayout.Space(20);

                    if(GUILayout.Button("Create Spawnable Waypoint Before "))
           {
               spawnable = 1;
                CreateWaypointBefore(spawnable);
           }


                   if(GUILayout.Button("Create Waypoint Before"))
           {
               spawnable = 0;
                CreateWaypointBefore(spawnable);
           }

           GUILayout.Space(20);
           GUILayout.Space(20);

            if(GUILayout.Button("Rename All Waypoints to Waypoint_SP"))
           {
               RenameWaypoints();
           }

GUILayout.Space(20);
            if(GUILayout.Button("Rename Selected Waypoints_SP to Waypoint"))
           {
               RenameSPWaypoints();
           }
       }

    void CreateBranch()
    {
        GameObject waypointObject = new GameObject("Waypoint " + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot,false);

        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();

            Debug.Log("Created Branch: " + waypoint.name);

        Waypoint branchedFrom = Selection.activeGameObject.GetComponent<Waypoint>();

        Debug.Log("Selected Waypoint: " + branchedFrom);

        branchedFrom.branches.Add(waypoint);

        waypoint.transform.position = branchedFrom.transform.position;
        waypoint.transform.forward = branchedFrom.transform.forward;

        Selection.activeGameObject = waypoint.gameObject;
    }

         void CreateWaypointBefore(int sp)
       {

           if (sp == 1)
           {
               wp = "Waypoint_SP ";             
           }
           else
           {
               wp = "Waypoint ";
                
           }
           
           GameObject waypointObject = new GameObject(wp + waypointRoot.childCount, typeof(Waypoint));

           waypointObject.transform.SetParent(waypointRoot, false);

           Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();

           Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

           waypointObject.transform.position = selectedWaypoint.transform.position;
           waypointObject.transform.forward = selectedWaypoint.transform.forward;

           if (selectedWaypoint.previousWaypoint != null)
           {
               newWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
               selectedWaypoint.previousWaypoint.nextWaypoint = newWaypoint;
           }

           newWaypoint.nextWaypoint = selectedWaypoint;

           selectedWaypoint.previousWaypoint = newWaypoint;

           newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

           Selection.activeGameObject = newWaypoint.gameObject;
       }


       void CreateWaypointAfter(int sp)
       {

         if (sp == 1)
           {
               wp = "Waypoint_SP ";
                
           }
           else
           {
               wp = "Waypoint ";
                
           }
           
            GameObject waypointObject = new GameObject(wp + waypointRoot.childCount, typeof(Waypoint));
           waypointObject.transform.SetParent(waypointRoot, false);

           Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();

           Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

              Debug.Log("Selected Waypoint: " + selectedWaypoint.name);
              Debug.Log("Next waypoint: " + selectedWaypoint.nextWaypoint);

           waypointObject.transform.position = selectedWaypoint.transform.position;
           waypointObject.transform.forward = selectedWaypoint.transform.forward;

                 newWaypoint.previousWaypoint = selectedWaypoint;
                    Debug.Log("new waypoint: " + newWaypoint);

                  //Debug.Log("Next waypoint: " + selectedWaypoint.nextWaypoint);

           if (selectedWaypoint.nextWaypoint  != null)
           {
               Debug.Log("Next waypoint: " + selectedWaypoint.nextWaypoint);
               selectedWaypoint.nextWaypoint.previousWaypoint = newWaypoint;
               newWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
               
           }

           selectedWaypoint.nextWaypoint = newWaypoint;

           //newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

           Selection.activeGameObject = newWaypoint.gameObject;


       }


          void RemoveWaypoint()
       {

  Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        if (selectedWaypoint.nextWaypoint  != null)
        {
                selectedWaypoint.nextWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
        }
        if (selectedWaypoint.previousWaypoint !=null)
        {
            selectedWaypoint.previousWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
            Selection.activeGameObject = selectedWaypoint.previousWaypoint.gameObject;
        }

            DestroyImmediate(selectedWaypoint.gameObject);

       }


   }


   void CreateWaypoint(int sp)
   {

         if (sp == 1)
           {
               wp = "Waypoint_SP ";
                
           }
           else
           {
               wp = "Waypoint ";
                
           }
           
       GameObject waypointObject = new GameObject(wp + waypointRoot.childCount, typeof(Waypoint));
       waypointObject.transform.SetParent(waypointRoot, false);

       Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
       if(waypointRoot.childCount >1)
       {
           waypoint.previousWaypoint = waypointRoot.GetChild(waypointRoot.childCount -2).GetComponent<Waypoint>();
           waypoint.previousWaypoint.nextWaypoint = waypoint;

           waypoint.transform.position = waypoint.previousWaypoint.transform.position;
           waypoint.transform.forward = waypoint.previousWaypoint.transform.forward;
       }

       Selection.activeGameObject = waypoint.gameObject;


       }

    void RenameWaypoints()
    {
        foreach(Transform child in waypointRoot)
        {
            old_name = child.gameObject.name;
            new_name = old_name.Replace("Waypoint_SP_SP", "Waypoint_SP");
            child.gameObject.name = new_name;
        }

    }
        
        void RenameSPWaypoints()
    {

  foreach (Transform transform in Selection.transforms)
  {
       old_name = transform.name;
       new_name = old_name.Replace("Waypoint_SP", "Waypoint");
       transform.name = new_name;
  }


    }
        

   

}
