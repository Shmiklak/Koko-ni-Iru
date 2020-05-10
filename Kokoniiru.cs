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
            dim(87233, 87709, 0);
            dim(115328, 117709, 1);
            dim(119614, 120090, 0);
            dim(199614, 200090, 0);
            dim(230090, 230566, 1);
            dim(226757, 230090, 0);
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
            //Gray
            bg.ColorHsb(19138, 0, 0, 0.35);
            //Purple
            bg.Color(26042, 0.4, 0.3, 0.7);
            //Green
            bg.Color(26280, 27709, 1, 1, 1, 0.1, 0.5, 0.2);
            //Dark blue
            bg.Color(57233, 58185, 0.1, 0.5, 0.2, 0, 0, 0.1);
            //Blue
            bg.Color(80090, 81042, 0, 0, 0.1, 0, 0.3, 0.5);
            bg.Fade(87709, 0);

            var bg2 = GetLayer("bg").CreateSprite("sb/etc/p.png", OsbOrigin.Centre);
            bg2.Scale(120090, 1000);
            bg2.Fade(120090, 1);
            bg2.Color(120090, 0.1, 0.1, 0.1);

            bg2.Color(135328, 0.5, 0.2, 0.4);

            bg2.Color(165804, 166757,  0.5, 0.2, 0.4, 0, 0, 0.1);

            bg2.Color(192471, 193423, 0, 0, 0.1, 0.7, 0.4, 0.3);

            bg2.Fade(200090, 0);

            var overlay = GetLayer("vig").CreateSprite("sb/etc/vig.png", OsbOrigin.Centre);
            overlay.Fade(19138, 21042, 0, 1);
            overlay.Fade(230566, 234376, 1, 0);
            overlay.Scale(19138, 0.45);
        }

        public void fuckingBell() {
            var position = new Vector2(320, 150);
            var bell = GetLayer("bell").CreateSprite("sb/etc/bell.png", OsbOrigin.TopCentre, position);
            bell.Fade(19138, 21042, 0, 1);
            bell.Scale(19138, 0.25);
            bell.StartLoopGroup(19138, 4);
            bell.Rotate(OsbEasing.InCubic, 0, beat * 2, -Math.PI / 2.5, Math.PI / 2.5);
            bell.Rotate(OsbEasing.InCubic, beat * 2, beat * 4, Math.PI / 2.5, -Math.PI / 2.5);
            bell.EndGroup();
            bell.Fade(26280, 0);
        }

        public void intro() {
            var noise = GetLayer("noise").CreateAnimation("sb/noise/static_.jpg", 4, 100, OsbLoopType.LoopForever, OsbOrigin.Centre);
            noise.Fade(90, 1995, 0, 0.6);
            noise.Fade(15328, 17233, 0.6, 0);
        }

        public void kiai(int startTime, int endTime) {

        }

        public void dim(int startTime, int endTime, int dur) {
            var bg = GetLayer("fg").CreateSprite("sb/etc/p.png", OsbOrigin.Centre);
            bg.Scale(startTime, 1000);
            bg.Fade(startTime, endTime, 0, 1);
            bg.Fade(endTime + beat * dur, endTime + beat * dur + beat * 2, 1, 0);
            bg.Color(startTime, 0, 0, 0);
        }
    }
}
