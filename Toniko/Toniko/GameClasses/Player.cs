// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="Aeream">
//   Durrrr
// </copyright>
// <summary>
//   Defines the Player type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Toniko.GameClasses
{
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;
	using Microsoft.Xna.Framework.Input;

	using Toniko;

	/// <summary>
	/// The player (Mario)
	/// </summary>
	public class Player
	{
		#region Fields
		/// <summary>
		/// The player's movement speed
		/// </summary>
		private const float Speed = 2.0f;
		
		/// <summary>
		/// The only instance of the class
		/// </summary>
		private static Player _instance;

		/// <summary>
		/// The amount of milliseconds each frame is to be displayed
		/// </summary>
		private readonly int _millisecondsPerFrame;

		/// <summary>
		/// The player sprite sheet
		/// </summary>
		private Texture2D _texture;

		/// <summary>
		/// The player's position
		/// </summary>
		private Vector2 _position;

		/// <summary>
		/// The amount of milliseconds that have passed since last frame was switched to
		/// </summary>
		private int _millisecondsSinceLastFrame;

		/// <summary>
		/// The frame which is currently being displayed
		/// </summary>
		private int _currentFrame;

		/// <summary>
		/// The first frame in the sprite sheet of the current animation based on current state
		/// </summary>
		private int _startFrame;

		/// <summary>
		/// The last frame in the sprite sheet ^
		/// </summary>
		private int _endFrame;

		/// <summary>
		/// The size of each frame in the sprite sheet
		/// </summary>
		private Point _frameSize;

		/// <summary>
		/// Whether or not the character is facing left; used for horizontal flipping in the Draw method
		/// </summary>
		private bool _facingLeft;

		/// <summary>
		/// Whether or not the character is in the air
		/// </summary>
		private bool _jumping;

		/// <summary>
		/// The state the player is currently in
		/// </summary>
		private State _currentState;

/*
		/// <summary>
		/// The previous keyboard state
		/// </summary>
		private KeyboardState _previousKeyboardState;
*/
		#endregion

		/// <summary>
		/// Prevents a default instance of the <see cref="Player"/> class from being created.
		/// </summary>
		private Player()
		{
			this._position = new Vector2(20, 400);

			this._currentFrame = 2;
			this._frameSize = new Point(66, 69);

			this._millisecondsPerFrame = 100;
			this._millisecondsSinceLastFrame = 0;

			this._currentState = State.Still;
		}

		/// <summary>
		/// The possible states for the player
		/// </summary>
		private enum State
		{
			/// <summary>
			/// Still: The player is standing still (not moving or jumping)
			/// </summary>
			Still,

			/// <summary>
			/// The player is moving sideways
			/// </summary>
			Walking,

			/// <summary>
			/// The player is in the air
			/// </summary>
			Jumping
		}

		/// <summary>
		/// Gets the instance of the class
		/// </summary>
		public static Player Instance
		{
			get { return _instance ?? (_instance = new Player()); }
		}

		#region Default methods
		/// <summary>
		/// Loads all required content
		/// </summary>
		public void LoadContent()
		{
			this._texture = Game1.Instance.Content.Load<Texture2D>(@"Images/mario_sprites");
		}

		/// <summary>
		/// Selects frames based on state, listens for user input
		/// </summary>
		/// <param name="gameTime">Delta time</param>
		public void Update(GameTime gameTime)
		{
			switch (this._currentState)
			{
				case State.Still:
					this._startFrame = 0;
					this._endFrame = 0;
					break;
				case State.Walking:
					this._startFrame = 1;
					this._endFrame = 2;
					break;
				case State.Jumping:
					this._startFrame = 3;
					this._endFrame = 3;
					break;
			}

			this._millisecondsSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

			if (this._millisecondsSinceLastFrame >= this._millisecondsPerFrame)
			{
				this._millisecondsSinceLastFrame -= this._millisecondsPerFrame;

				if (this._currentFrame++ >= this._endFrame)
				{
					this._currentFrame = this._startFrame;
				}
			}

			KeyboardState keyboardState = Keyboard.GetState();

			if (keyboardState.IsKeyDown(Keys.Right))
			{
				this._position.X += Speed;
				this._currentState = State.Walking;
				this._facingLeft = false;
			}
			else if (keyboardState.IsKeyDown(Keys.Left))
			{
				this._position.X -= Speed;
				this._currentState = State.Walking;
				this._facingLeft = true;
			}
			else
			{
				if (!this._jumping)
				{
					this._currentState = State.Still;
				}
			}

			if (keyboardState.IsKeyDown(Keys.Up))
			{
				this.Jump();
			}
		}

		/// <summary>
		/// Draws the player
		/// </summary>
		public void Draw()
		{
			Game1.Instance.SpriteBatch.Draw(this._texture, this._position, new Rectangle(this._currentFrame * this._frameSize.X, 0, this._frameSize.X, this._frameSize.Y), Color.White, 0, Vector2.Zero, 1, this._facingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
		}
		#endregion

		/// <summary>
		/// Jump method
		/// </summary>
		private void Jump()
		{
			/*
			 * Set some boolean to true so _currentState doesn't go back to Still
			 * Move character in an arc
			 * Set the same boolean to false
			 */

			this._jumping = true;
			/*
			 * Do stuff while gameTime something
			 */
			this._jumping = false;
		}
	}
}
