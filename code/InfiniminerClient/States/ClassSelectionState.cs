using System;
using System.Collections.Generic;

using System.Text;
using System.Diagnostics;
using StateMasher;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Microsoft.Xna.Framework.Storage;

namespace Infiniminer.States
{
    public class ClassSelectionState : State
    {
        Texture2D texMenuRed, texMenuBlue;
        Rectangle drawRect;
        string nextState = null;
        bool canCancel = false;

        ClickRegion[] clkClassMenu = new ClickRegion[4] {
	        new ClickRegion(new Rectangle(54,168,142,190), "miner"), 
	        new ClickRegion(new Rectangle(300,169,142,190), "prospector"), 
	        new ClickRegion(new Rectangle(580,170,133,187), "engineer"), 
	        new ClickRegion(new Rectangle(819,172,133,190), "sapper")//,
            //new ClickRegion(new Rectangle(0,0,0,0), "cancel")
        };

        public override void OnEnter(string oldState)
        {
            _SM.IsMouseVisible = true;

            texMenuRed = _SM.ScratchContent.Load<Texture2D>("menus/tex_menu_class_red");
            texMenuBlue = _SM.ScratchContent.Load<Texture2D>("menus/tex_menu_class_blue");

            drawRect = new Rectangle(_SM.GraphicsDevice.Viewport.Width / 2 - 1024 / 2,
                                     _SM.GraphicsDevice.Viewport.Height / 2 - 768 / 2,
                                     1024,
                                     768);

            if (oldState == "Infiniminer.States.MainGameState")
                canCancel = true;
            //_P.KillPlayer("");
        }

        public override void OnLeave(string newState)
        {
            //_P.RespawnPlayer();
            _SM.ScratchContent.Unload();
        }

        public override string OnUpdate(GameTime gameTime, KeyboardState keyState, MouseState mouseState)
        {
            // Do network stuff.
            (_SM as InfiniminerGame).UpdateNetwork(gameTime);

            _P.skyplaneEngine.Update(gameTime);
            _P.playerEngine.Update(gameTime);
            _P.interfaceEngine.Update(gameTime);
            _P.particleEngine.Update(gameTime);

            return nextState;
        }

        public override void OnRenderAtEnter(GraphicsDevice graphicsDevice)
        {

        }

        public override void OnRenderAtUpdate(GraphicsDevice graphicsDevice, GameTime gameTime)
        {
            SpriteBatch spriteBatch = _P.spriteBatch;
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            Texture2D teamClasses = (_P.playerTeam == PlayerTeam.Red) ? texMenuRed : texMenuBlue;
            spriteBatch.Draw(teamClasses, drawRect, new Rectangle(0, 0, 1024, 768), Color.White);
            spriteBatch.End();
        }

        public override void OnKeyDown(Keys key)
        {
            if (key == Keys.Escape && canCancel)
                nextState = "Infiniminer.States.MainGameState";
        }

        public override void OnKeyUp(Keys key)
        {

        }

        public override void OnMouseDown(MouseButton button, int x, int y)
        {
            x -= drawRect.X;
            y -= drawRect.Y;
            switch (ClickRegion.HitTest(clkClassMenu, new Point(x, y)))
            {
                case "miner":
                    _P.SetPlayerClass(PlayerClass.Miner);
                    nextState = "Infiniminer.States.MainGameState";
                    _P.PlaySound(InfiniminerSound.ClickHigh);
                    break;
                case "engineer":
                    _P.SetPlayerClass(PlayerClass.Engineer);
                    nextState = "Infiniminer.States.MainGameState";
                    _P.PlaySound(InfiniminerSound.ClickHigh);
                    break;
                case "prospector":
                    _P.SetPlayerClass(PlayerClass.Prospector);
                    nextState = "Infiniminer.States.MainGameState";
                    _P.PlaySound(InfiniminerSound.ClickHigh);
                    break;
                case "sapper":
                    _P.SetPlayerClass(PlayerClass.Sapper);
                    nextState = "Infiniminer.States.MainGameState";
                    _P.PlaySound(InfiniminerSound.ClickHigh);
                    break;
                case "cancel":
                    nextState = "Infiniminer.States.MainGameState";
                    _P.PlaySound(InfiniminerSound.ClickHigh);
                    break;
            }
        }

        public override void OnMouseUp(MouseButton button, int x, int y)
        {

        }

        public override void OnMouseScroll(int scrollDelta)
        {

        }
    }
}
