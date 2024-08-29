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
    /// <typeparam name="PlayerHurt"></typeparam>
    public class PlayerHurt : Simulation.Event<PlayerHurt>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            player.health.Decrement();
            if (player.health.IsAlive)
            {
                if (player.audioSource && player.ouchAudio)
                {
                    player.audioSource.PlayOneShot(player.ouchAudio);
                }
                player.animator.SetTrigger("hurt");
            }
            else
            {
                Simulation.Schedule<PlayerDeath>(0);
            }
        }
    }
}