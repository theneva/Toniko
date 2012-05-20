// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enemy.cs" company="X">
//   Durrrr
// </copyright>
// <summary>
//   Defines the Enemy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Toniko.GameClasses
{
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class Enemy
	{
		/// <summary>
		/// The amount of milliseconds each frame is to be displayed
		/// </summary>
		private readonly int _millisecondsPerFrame;
		
		/// <summary>
		/// Horizontal movement speed
		/// </summary>
		private float _speed;

		/// <summary>
		/// The enemy sprite sheet
		/// </summary>
		private Texture2D _texture;

		/// <summary>
		/// The enemy's position
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
		/// Initializes a new instance of the <see cref="Enemy"/> class.
		/// </summary>
		/// <param name="name">
		/// The name of the enemy type
		/// </param>
		public Enemy(string name)
		{
			this._speed = 3.5f;

			this.Initialize(name);
			this.LoadContent(name);
		}

		/// <summary>
		/// Updates the enemy
		/// </summary>
		/// <param name="gameTime">
		/// The game time.
		/// </param>
		public void Update(GameTime gameTime)
		{
			this._position.X -= this._speed;
		}

		/// <summary>
		/// Draws the enemy
		/// </summary>
		public void Draw()
		{
			//HQ.Instance.SpriteBatch.Draw(this._texture, this._position, new Rectangle(this._currentFrame * this._frameSize.X, 0, this._frameSize.X, this._frameSize.Y), Color.White, 0, Vector2.Zero, 1, this._facingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
			HQ.Instance.SpriteBatch.Draw(this._texture, this._position, Color.White);
		}

		/// <summary>
		/// Loads all nongraphic content
		/// </summary>
		/// <param name="name">
		/// The name of the enemy type
		/// </param>
		private void Initialize(string name)
		{
			switch (name.ToLower())
			{
				case "goomba":
					this._speed = 1.5f;
					break;
				case "turtle":
					this._speed = 2.5f;
					break;
			}
		}

		/// <summary>
		/// Loads all graphic content
		/// </summary>
		/// <param name="name">
		/// The name of the enemy type
		/// </param>
		private void LoadContent(string name)
		{
			this._texture = HQ.Instance.Content.Load<Texture2D>(@"Images/Enemies/" + name + "/texture");
		}
	}
}
