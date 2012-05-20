// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Game1.cs" company="X">
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
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		public GraphicsDeviceManager Graphics;
		public SpriteBatch SpriteBatch;

		#region Singleton constructor
		private static Game1 _instance;
		public static Game1 Instance
		{
			get { return _instance ?? (_instance = new Game1()); }
		}

		private Game1()
		{
			this.Graphics = new GraphicsDeviceManager(this);
			this.Content.RootDirectory = "Content";
		}
		#endregion

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

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
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
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
