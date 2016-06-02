using UnityEngine;
using System.Collections;

public class PrisonerExit : MonoBehaviour {

    public GameObject player;

    public int health;
    public int damage;

    public int score;
    public int scorePenalty;


	void OnTriggerEnter (Collider other) {
        if (other.gameObject != player)
        {
            Destroy(other.gameObject);
            //different foe, different damage
            //health -= other.gameObject.damage;
            //same damage for all
            health -= damage;


            score -= scorePenalty;
        }
	}
}
