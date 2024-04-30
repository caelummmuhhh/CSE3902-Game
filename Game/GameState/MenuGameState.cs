using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Linq;
using MainGame.SpriteHandlers;
using MainGame.Controllers;

namespace MainGame;
public class MenuGameState : IGameState
{
    public readonly List<IController> controllers = new();
    private readonly Game1 game;
    private readonly SpriteBatch spriteBatch;
    private readonly Dictionary<string, Effect> ShaderOptions = new();
    private KeyValuePair<string, Effect> selectedShader;

    private readonly ISprite ShaderTitleText;
    private ISprite CurrentShaderText;

    public MenuGameState(Game1 game, SpriteBatch spriteBatch, ContentManager contents)
    {
        this.game = game;
        this.spriteBatch = spriteBatch;
        
        string[] shaderFiles = Directory.GetFiles(Path.Combine("Content", "Shaders"));
        ShaderOptions.Add("None", null);
        selectedShader = new("None", ShaderOptions["None"]);

        foreach (string shaderFile in shaderFiles)
        {
            string shaderName = Path.GetFileNameWithoutExtension(shaderFile);
            if (shaderName == "UsefulShaderFunctions") continue;
            ShaderOptions.Add(shaderName, contents.Load<Effect>($"Shaders/{shaderName}"));
        }

        ShaderTitleText = SpriteFactory.CreateTextSprite("SHADER: ", DefaultSpriteLayerDepths.MenuLayer);
        controllers.Add(new MenuKeyboardController(game, this));
    }

    public void Update(GameTime gameTime)
    {
        for (int i = 0; i < controllers.Count; i++)
        {
            controllers[i].Update();
        }
    }
    
    public void Draw(GameTime gameTime)
    {
        CurrentShaderText = SpriteFactory.CreateTextSprite(selectedShader.Key, DefaultSpriteLayerDepths.MenuLayer);

        ShaderTitleText.Draw(16 * Constants.UniversalScale, 32  * Constants.UniversalScale, Color.White);
        CurrentShaderText.Draw(128 * Constants.UniversalScale, 32  * Constants.UniversalScale, Color.LightPink);
    }

    public void NextShaderOption()
    {
        List<string> shaderNames = ShaderOptions.Keys.ToList();
        int currentShaderIndex = shaderNames.IndexOf(selectedShader.Key);
        currentShaderIndex = (currentShaderIndex + 1) % ShaderOptions.Count;

        selectedShader = new(shaderNames[currentShaderIndex], ShaderOptions[shaderNames[currentShaderIndex]]);
        game.ShaderEffect = selectedShader.Value;
    }
}
