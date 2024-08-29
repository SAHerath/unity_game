using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
// using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has hurt.
    /// </summary>
    /// <typeparam name="PlayerHurtSpawn"></typeparam>
    public class PlayerHurtSpawn : Simulation.Event<PlayerHurtSpawn>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            player.health.Decrement();
            if (player.health.IsAlive)
            {   
                model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;
                // // player.collider.enabled = false;
                player.controlEnabled = false;

                if (player.audioSource && player.ouchAudio)
                {
                    player.audioSource.PlayOneShot(player.ouchAudio);
                }
                player.animator.SetTrigger("hurt");
                player.animator.SetBool("dead", true);
                Simulation.Schedule<PlayerSpawn>(2);
            }
            else
            {
                Simulation.Schedule<PlayerDeath>(0);
            }
        }
    }
}