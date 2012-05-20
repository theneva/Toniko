// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="X">
//   Durrr
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Toniko
{
	using Toniko;

#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (HQ game = HQ.Instance)
            {
                game.Run();
            }
        }
    }
#endif
}

