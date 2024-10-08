using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireFootsteps : MonoBehaviour
{
    private enum CURRENT_TERRAIN {Grass, Mud, Stone, Inside};  
    
    [SerializeField] private CURRENT_TERRAIN currentTerrain;
    private FMOD.Studio.EventInstance footsteps;

     private void Update() 
    {
        DetermineTerrain();
    }

    //could determine terrain each time move buttons are clicked rather than doing it in a void update?
    private void DetermineTerrain()
    {
        //checks below player to see what they're standing on, as a hit,
        RaycastHit[] hit;
        hit = Physics.RaycastAll(transform.position, Vector3.down, 10.0f);
 
        foreach (RaycastHit rayhit in hit)
        {
            if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Grass"))
            {
                currentTerrain = CURRENT_TERRAIN.Grass;
                break;
            }

            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Mud"))
            {
                currentTerrain = CURRENT_TERRAIN.Mud;
                break;
            }

            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Stone"))
            {
                currentTerrain = CURRENT_TERRAIN.Stone;
                break;
            }

            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Inside"))
            {
                currentTerrain = CURRENT_TERRAIN.Inside;
                break;
            }
        }
    }

    public void SelectAndPlayFoostep()
    {
        //number corrosponds with parameter value in FMOD
        switch (currentTerrain)
        {
            case CURRENT_TERRAIN.Grass:
                PlayFootstep(1);
                break;

            case CURRENT_TERRAIN.Mud:
                PlayFootstep(2);
                break;
            
            case CURRENT_TERRAIN.Stone:
                PlayFootstep(3);
                break;

            case CURRENT_TERRAIN.Inside:
                PlayFootstep(0);
                break;        
        }
    }

    private void PlayFootstep(int terrain)  
    {
        footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Vampire/Footsteps");
        footsteps.setParameterByName("Terrain", terrain);
        footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        footsteps.start();
        footsteps.release();
    }
}
