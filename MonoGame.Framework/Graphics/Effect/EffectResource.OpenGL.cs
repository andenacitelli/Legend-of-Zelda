// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Graphics
{
#if WEB
    internal partial class EffectResource
    {
        const string AlphaTestEffectName = "AlphaTestEffect.ogl.mgfxo";
        const string BasicEffectName = "BasicEffect.ogl.mgfxo";
        const string DualTextureEffectName = "DualTextureEffect.ogl.mgfxo";
        const string EnvironmentMapEffectName = "EnvironmentMapEffect.ogl.mgfxo";
        const string SkinnedEffectName = "SkinnedEffect.ogl.mgfxo";
        const string SpriteEffectName = "SpriteEffect.ogl.mgfxo";
    }
#else
    internal partial class EffectResource
    {
        const string AlphaTestEffectName = "Microsoft.Xna.Framework.Graphics.Effect.Resources.AlphaTestEffect.ogl.mgfxo";
        const string BasicEffectName = "Microsoft.Xna.Framework.Graphics.Effect.Resources.BasicEffect.ogl.mgfxo";
        const string DualTextureEffectName = "Microsoft.Xna.Framework.Graphics.Effect.Resources.DualTextureEffect.ogl.mgfxo";
        const string EnvironmentMapEffectName = "Microsoft.Xna.Framework.Graphics.Effect.Resources.EnvironmentMapEffect.ogl.mgfxo";
        const string SkinnedEffectName = "Microsoft.Xna.Framework.Graphics.Effect.Resources.SkinnedEffect.ogl.mgfxo";
        const string SpriteEffectName = "Microsoft.Xna.Framework.Graphics.Effect.Resources.SpriteEffect.ogl.mgfxo";
    }
#endif
}
