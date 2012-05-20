// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HQ.cs" company="X">
//   Durrr
// </copyright>
// <summary>
//   This is the main type for your game
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Toniko
{
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;
	using Microsoft.Xna.Framework.Input;

	using Toniko.GameClasses;

	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class HQ : Game
	{
		/// <summary>
		/// The only instance of the class
		/// </summary>
		private static HQ _instance;

		/// <summary>
		/// The game's GraphicsDeviceManager
		/// </summary>
		private GraphicsDeviceManager _graphics;

		/// <summary>
		/// Prevents a default instance of the <see cref="HQ"/> class from being created.
		/// </summary>
		private HQ()
		{
			this._graphics = new GraphicsDeviceManager(this);
			this.Content.RootDirectory = "Content";

			this.SpeedMultiplier = 1.0f;
		}

		/// <summary>
		/// Gets the instance of the class
		/// </summary>
		public static HQ Instance
		{
			get { return _instance ?? (_instance = new HQ()); }
		}

		/// <summary>
		/// Gets the SpriteBatch used for drawing by all classes
		/// </summary>
		public SpriteBatch SpriteBatch { get; private set; }

		/// <summary>
		/// Gets or sets SpeedMultiplier.
		/// </summary>
		public float SpeedMultiplier { get; set; }

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			Player.Instance.Initialize();
			EnemyHandler.Instance.Initialize();

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);

			// TODO: use this.Content to load your game content here
			Player.Instance.LoadContent();
		}

		/// <summary>
		/// This method does fuck all
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
			{
				this.Exit();
			}

			// TODO: Add your update logic here
			Player.Instance.Update(gameTime);
			EnemyHandler.Instance.Update(gameTime);

			this.SpeedMultiplier = Keyboard.GetState().IsKeyDown(Keys.Space) ? 3.0f : 1.0f;

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			this.GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			this.SpriteBatch.Begin();
			Player.Instance.Draw();
			this.SpriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
