using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.View
{
    public class MovingPlatform : MonoBehaviour
    {
        public Transform pointA;
        public Transform pointB;
        public float speed = 2f;

        private Vector3 nextPosition;
        // public PlayerController player;

        // Start is called before the first frame update
        void Start()
        {
            nextPosition = pointB.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

            if(transform.position == nextPosition)
            {
                nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.transform.parent = transform;
            }

        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            // var player = collision.gameObject.GetComponent<PlayerController>();
            // if (player != null)
            if(collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.transform.parent = null;
            }
        }
    }
}