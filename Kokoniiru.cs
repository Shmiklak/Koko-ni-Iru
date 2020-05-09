using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Kokoniiru : StoryboardObjectGenerator
    {
        public static int beat = 19614 - 19138;
        public override void Generate()
        {
            intro();
            fuckingBell();
		    getRidOfBackground();
            background();
        }

        public void getRidOfBackground() {
            var bitmap = GetMapsetBitmap(Beatmap.BackgroundPath);
            var bg = GetLayer("bg").CreateSprite(Beatmap.BackgroundPath, OsbOrigin.Centre);
            bg.Fade(0, 0);
        }

        public void background() {
            var bg = GetLayer("bg").CreateSprite("sb/etc/p.png", OsbOrigin.Centre);
            bg.Scale(19138, 1000);
            bg.Fade(19138, 21042, 0, 1);
            bg.Fade(230566, 234376, 1, 0);
            bg.ColorHsb(19138, 0, 0, 0.35);


            var overlay = GetLayer("bg").CreateSprite("sb/etc/vig.png", OsbOrigin.Centre);
            overlay.Fade(19138, 21042, 0, 1);
            overlay.Fade(230566, 234376, 1, 0);
            overlay.Scale(19138, 0.45);
        }

        public void fuckingBell() {
            var bell = GetLayer("bell").CreateSprite("sb/etc/bell.png", OsbOrigin.TopCentre);
            bell.StartLoopGroup(0, 10);
            bell.Rotate(0, beat, 0, Math.PI);
            bell.Rotate(beat, beat * 2, Math.PI, -Math.PI);
            bell.EndGroup();
        }

        public void intro() {
            var noise = GetLayer("noise").CreateAnimation("sb/noise/static_.jpg", 4, 100, OsbLoopType.LoopForever, OsbOrigin.Centre);
            noise.Fade(90, 1995, 0, 0.6);
            noise.Fade(15328, 17233, 0.6, 0);
        }
    }
}
