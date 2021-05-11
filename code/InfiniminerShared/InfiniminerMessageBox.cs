using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if SDL2
using SDL2;
#else
using System.Windows.Forms;
#endif


namespace Infiniminer
{
    public static class InfiniminerMessageBox
    {
        public static void Show(string message)
        {
#if SDL2
            SDL.SDL_ShowSimpleMessageBox(
                SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_ERROR,
                "Infiniminer",
                message,
                new IntPtr() // hopefully this doesn't break everything
            );
#else
            MessageBox.Show(message);
#endif
        }
    }
}
