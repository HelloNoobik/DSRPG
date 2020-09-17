using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Resources
{
    static class Links
    {
        static public class Img
        {
            static public Uri Lotrik = new Uri("Resources/img/Lotrik.png", UriKind.Relative);
            static public Uri YellowLevel = new Uri("Resources/img/lvl (2).png", UriKind.Relative);
            static public Uri YellowLevelActive = new Uri("Resources/img/lvl_active.png", UriKind.Relative);
            static public Uri GrayLevel = new Uri("Resources/img/noPass.png", UriKind.Relative);
            static public Uri GrayLevelActive = new Uri("Resources/img/noPass_active.png", UriKind.Relative);
            static public Uri BoneFire = new Uri("Resources/img/skewer.png", UriKind.Relative);
            static public Uri BattleBg = new Uri("Resources/img/Throne_Of_Want.png", UriKind.Relative);
            static public Uri World = new Uri("Resources/img/World.jpg", UriKind.Relative);
        }

        static public class Sound
        {
            static public Uri Click = new Uri("Resources/sound/click.mp3", UriKind.Relative);
        }

        static public class Music
        {
            static public Uri Main = new Uri("Resources/music/MainTheme.mp3", UriKind.Relative);
            static public Uri World = new Uri("Resources/music/WorldOST.mp3", UriKind.Relative);
        }

        static public class Video
        {
            static public Uri Intro = new Uri("Resources/video/DS_opening.mp4", UriKind.Relative);
        }
    }
}
