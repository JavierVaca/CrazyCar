using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class player_controller
    {

        private Player CreatePlayer()
        {
            IPlayer playerController = Substitute.For<IPlayer>();
            Player player = new Player(playerController);
            player.playerInput = Substitute.For<IPlayerInput>();
            return player;
        }

        [Test]
        public void player_move_right()
        {
            var player = CreatePlayer();
            player.playerInput.Horizontal.Returns(1f);
            bool grounded = true;


            Vector3 resultDirection = player.GetMoveDirection(grounded);
            Vector3 expectedDirection = new Vector3(1,0,0);

            Assert.AreEqual(expectedDirection, resultDirection);
        }

        [Test]
        public void player_move_left()
        {
             var player = CreatePlayer();
            player.playerInput.Horizontal.Returns(-1f);
            bool grounded = true;


            Vector3 resultDirection = player.GetMoveDirection(grounded);
            Vector3 expectedDirection = new Vector3(-1,0,0);

            Assert.AreEqual(expectedDirection, resultDirection);
        }

        [Test]
        public void player_move_jump()
        {
             var player = CreatePlayer();
            player.playerInput.JumpVertical.Returns(true);
            bool grounded = true;


            Vector3 resultDirection = player.GetMoveDirection(grounded);
            Vector3 expectedDirection = new Vector3(0,1,0);

            Assert.AreEqual(expectedDirection, resultDirection);
        }

        [Test]
        public void player_jump_move_right()
        {
             var player = CreatePlayer();
            player.playerInput.Horizontal.Returns(1f);
            player.playerInput.JumpVertical.Returns(true);
            bool grounded = true;


            Vector3 resultDirection = player.GetMoveDirection(grounded);
            Vector3 expectedDirection = new Vector3(1,1,0);

            Assert.AreEqual(expectedDirection, resultDirection);
        }

        [Test]
        public void player_jump_move_left()
        {
            var player = CreatePlayer();
            player.playerInput.Horizontal.Returns(-1f);
            player.playerInput.JumpVertical.Returns(true);
            bool grounded = true;


            Vector3 resultDirection = player.GetMoveDirection(grounded);
            Vector3 expectedDirection = new Vector3(-1,1,0);

            Assert.AreEqual(expectedDirection, resultDirection);
        }
    }
}