using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpostorScript : MonoBehaviour
{
    [SerializeField]
    public GameObject vent;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timer;
    [SerializeField]
    public PointScript pScript;

    void Start()
    {
        speed = Random.Range(10f, 15f);
        vent = GameObject.FindGameObjectWithTag("Objective");
        pScript = FindObjectOfType<PointScript>();
    }

    void Update()
    {
        MoveImpostor();
        LookRotation();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Vent Objective")
        {
            Debug.Log("You Should have lost here, but since this is a test it doesn't matter");
            pScript.HP -= 10;
            Destroy(gameObject);
        }
    }

    void LookRotation()
    {
        Vector3 relativepos = vent.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativepos, Vector3.up);
        transform.rotation = rotation;

    }

    void MoveImpostor()
    {
        timer += Time.deltaTime;
        float divider = timer * Time.deltaTime / speed;
        var move = Vector3.Lerp(transform.position, vent.transform.position, divider);
        transform.position = move;
    }
}
