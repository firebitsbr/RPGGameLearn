﻿using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Control;
using RPG.Core;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics 
{
    public class CinematicControlRemover : MonoBehaviour 
    {
        private PlayableDirector director;
        private GameObject player;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            director = GetComponent<PlayableDirector>();
            
            director.played += OnDirectorPlayed;
            director.stopped += OnDirectorStopped;
        }

        private void OnDirectorStopped(PlayableDirector obj)
        {
            player.GetComponent<PlayerController>().enabled = true;
        }

        private void OnDirectorPlayed(PlayableDirector obj)
        {
            player.GetComponent<ActionScheduler>().CancelCurrentAction();
            player.GetComponent<PlayerController>().enabled = false;

        }
    }

}