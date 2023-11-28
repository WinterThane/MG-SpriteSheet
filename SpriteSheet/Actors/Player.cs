﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpriteSheet.SpriteAnimation;

namespace SpriteSheet.Actors
{
    public class Player
    {
        private Vector2 _position = new(200, 200);
        private readonly float _speed = 200f;
        private readonly AnimationManager _animations = new();

        public Player()
        {
            var playerTexture = Globals.Content.Load<Texture2D>("PlayerMap");
            _animations.AddAnimation(new Vector2(0, 1), new(playerTexture, 8, 8, 0.1f, 1));
            _animations.AddAnimation(new Vector2(-1, 0), new(playerTexture, 8, 8, 0.1f, 2));
            _animations.AddAnimation(new Vector2(1, 0), new(playerTexture, 8, 8, 0.1f, 3));
            _animations.AddAnimation(new Vector2(0, -1), new(playerTexture, 8, 8, 0.1f, 4));
            _animations.AddAnimation(new Vector2(-1, 1), new(playerTexture, 8, 8, 0.1f, 5));
            _animations.AddAnimation(new Vector2(-1, -1), new(playerTexture, 8, 8, 0.1f, 6));
            _animations.AddAnimation(new Vector2(1, 1), new(playerTexture, 8, 8, 0.1f, 7));
            _animations.AddAnimation(new Vector2(1, -1), new(playerTexture, 8, 8, 0.1f, 8));
        }

        public void Update()
        {
            if (InputManager.IsMoving)
            {
                _position += Vector2.Normalize(InputManager.Direction) * _speed * Globals.TotalSeconds;
            }

            _animations.Update(InputManager.Direction);
        }

        public void Draw()
        {
            _animations.Draw(_position);
        }
    }
}
