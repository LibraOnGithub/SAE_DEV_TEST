using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace JeuxMonogame
{
    public class Game1 : Game
    {
        public SpriteBatch SpriteBatch { get; set; }
        private MyScreen1 _myScreen1;
        private MyScreen2 _myScreen2;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 _positionPersoPrincipale;
        private int _vitessePersoPrincipale = 5;
        private AnimatedSprite _persoPrincipale;
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private AnimatedSprite persoPrincipale;
        private readonly ScreenManager _screenManager;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _positionPersoPrincipale = new Vector2(20, 340);
            base.Initialize();
            
        }

        protected override void LoadContent()
        {   
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tiledMap = Content.Load<TiledMap>("Vanquiom");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            _myScreen1 = new MyScreen1(this); // en leur donnant une référence au Game
            _myScreen2 = new MyScreen2(this);

            // TODO: use this.Content to load your game content here

            SpriteSheet spriteSheet = Content.Load<SpriteSheet>("PersoPrincipaleAnimation.sf", new JsonContentLoader());
            _persoPrincipale = new AnimatedSprite(spriteSheet);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _screenManager.LoadScreen(_myScreen1, new FadeTransition(GraphicsDevice,
                Color.Black));
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                _screenManager.LoadScreen(_myScreen2, new FadeTransition(GraphicsDevice,
                Color.Black));
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}