using System.Collections.Generic;
using System.Linq;
using ExtremelySimpleLogger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Data;
using MLEM.Data.Content;
using MLEM.Textures;
using TinyLife;
using TinyLife.Mods;
using TinyLife.Objects;
using TinyLife.Utilities;

namespace ExtraClothes {
    public class ExtraClothes : Mod {

        // the logger that we can use to log info about this mod
        public static Logger Logger { get; private set; }

        // visual data about this mod
        public override string Name => "Extra Clothes";
        public override string Description => "An assortment of clothing options for your characters in Tiny Life.";
        public override TextureRegion Icon => this.uiTextures[0, 0];

        private UniformTextureAtlas shirtComboTex;
        private UniformTextureAtlas stripedShirtLongTex;
        private UniformTextureAtlas cargoPantsTex;
        private UniformTextureAtlas uiTextures;

        public override void AddGameContent(GameImpl game) {

/*
            // Template for new clothing items (Replace <VALUE> areas).

            // Full Name of Item
            var <VAR ITEM NAME> = new Clothes(
                "ExtraClothes.<ITEM NAME>", ClothesLayer.<ITEM TYPE>,
                this.<TEXTURE NAME>[0, 0],
                <PRICE>,
                ClothesIntention.Everyday | ClothesIntention.Workout,
                this.Icon, false, ColorScheme.<SCHEME NAME>
                );
                Clothes.Register(<VAR ITEM NAME>);
*/

            // Tops (Shirts, jackets, Hoodies, etc.)
            // T-shirt & Button-down Combo
            var shirtCombo = new Clothes(
                "ExtraClothes.ShirtCombo", ClothesLayer.Shirt,
                this.shirtComboTex[0, 0],
                300,
                ClothesIntention.Everyday | ClothesIntention.Workout,
                this.Icon, false, ColorScheme.WarmDark
                );
                Clothes.Register(shirtCombo);

            // Striped Long-sleeve Shirt
            var stripedShirtLong = new Clothes(
                "ExtraClothes.StripedShirtLong", ClothesLayer.Shirt,
                this.stripedShirtLongTex[0, 0],
                130,
                ClothesIntention.Everyday | ClothesIntention.Workout,
                this.Icon, false, ColorScheme.WarmDark
                );
            Clothes.Register(stripedShirtLong);


            // Bottoms (Pants, Shorts, Skirts, etc.)
            // Cargo Pants
            var cargoPants = new Clothes(
                "ExtraClothes.CargoPants", ClothesLayer.Pants,
                this.cargoPantsTex[0, 0],
                175,
                ClothesIntention.Everyday | ClothesIntention.Workout,
                this.Icon, false, ColorScheme.WarmDark
                );
            Clothes.Register(cargoPants);
        }

        public override void Initialize(
            Logger logger, RawContentManager content,
            RuntimeTexturePacker texturePacker) {
                Logger = logger;

/*
                texturePacker.Add(
                    content.Load<Texture2D>("<TEXTURE FILENAME>"),
                    r => this.<TEXTURE VAR NAME> = new UniformTextureAtlas(r, 4, 8)
                    );
*/

                texturePacker.Add(
                    content.Load<Texture2D>("ShirtCombo"),
                    r => this.shirtComboTex = new UniformTextureAtlas(r, 4, 8)
                    );

                texturePacker.Add(
                    content.Load<Texture2D>("StripedShirtLong"),
                    r => this.stripedShirtLongTex = new UniformTextureAtlas(r, 4, 8)
                    );

                texturePacker.Add(
                    content.Load<Texture2D>("CargoPants"),
                    r => this.cargoPantsTex = new UniformTextureAtlas(r, 4, 8)
                    );

                texturePacker.Add(
                    content.Load<Texture2D>("UiTextures"),
                    r => this.uiTextures = new UniformTextureAtlas(r, 8, 8)
                    );
        }
    }
}
