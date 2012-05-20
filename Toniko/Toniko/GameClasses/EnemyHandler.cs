// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnemyHandler.cs" company="X">
//   Durrr
// </copyright>
// <summary>
//   Defines the EnemyHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Toniko.GameClasses
{
	using System.Collections.Generic;

	using Microsoft.Xna.Framework;

	/// <summary>
	/// Takes care of each enemy instance
	/// </summary>
	public class EnemyHandler
	{
		/// <summary>
		/// The only instance of the class
		/// </summary>
		private static EnemyHandler _instance;

		/// <summary>
		/// A list containing each enemy
		/// </summary>
		private List<Enemy> _enemies;

		private int _millisecondsSinceLastAdd;

		private readonly int _millisecondsPerAdd;

		/// <summary>
		/// Prevents a default instance of the <see cref="EnemyHandler"/> class from being created.
		/// </summary>
		private EnemyHandler()
		{
			_millisecondsSinceLastAdd = 0;
			_millisecondsPerAdd = 1000;
		}

		/// <summary>
		/// Gets the only instance of EnemyHandler
		/// </summary>
		public static EnemyHandler Instance
		{
			get { return _instance ?? (_instance = new EnemyHandler()); }
		}

		#region Default methods
		/// <summary>
		/// Initialises the list
		/// </summary>
		public void Initialize()
		{
			this._enemies = new List<Enemy>();
		}

		/// <summary>
		/// Updates each enemy in the list
		/// </summary>
		/// <param name="gameTime">
		/// The game time.
		/// </param>
		public void Update(GameTime gameTime)
		{
			if ((this._millisecondsSinceLastAdd += gameTime.ElapsedGameTime.Milliseconds) >= this._millisecondsPerAdd)
			{
				this._millisecondsSinceLastAdd -= this._millisecondsPerAdd;
				this._enemies.Add(new Enemy("turtle"));
			}

			foreach (var enemy in this._enemies)
			{
				enemy.Update(gameTime);
			}
		}

		/// <summary>
		/// Draws each enemy in the list
		/// </summary>
		public void Draw()
		{
			foreach (var enemy in this._enemies)
			{
				enemy.Draw();
			}
		}

		#endregion
	}
}
