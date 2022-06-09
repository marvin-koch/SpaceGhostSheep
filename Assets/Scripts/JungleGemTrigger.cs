using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleGemTrigger : MonoBehaviour
{
    public AudioSource gemTaken;
    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        gemTaken.Play();
        other.gameObject.GetComponent<public_variables>().score += 1;
        JungleGameManager.gems -= 1;
         if(!Timer.paused){
            for(int i = 0; i < 3; ++i){
                if(players[i].GetComponent<JunglePlayerBehaviour>() == null){
                    players[i].GetComponent<StupidAnimalBehaviour>().visualEffectSet = false;
                }else{
                    players[i].GetComponent<JunglePlayerBehaviour>().visualEffectSet = false;
                }
            }
        }
        Destroy(this.gameObject);
    }
}
