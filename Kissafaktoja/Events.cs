using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kissafaktoja
{
    public class CatArgs
    {
        public ImageButton CatImage { get; set; } 
        
    }

    public class CatEvents
    {

        public static void OnGetCatEvent(object sender, CatArgs e)
        {
            
            Random degrees = new();
            int rot = degrees.Next(360);
            uint speed = (uint)degrees.Next(5000);

            e.CatImage.RotateTo(rot, speed);
            e.CatImage.Rotation = 0;

            Random direction = new();
            int x = direction.Next(250);
            int y = direction.Next(250);
            e.CatImage.TranslateTo(x, y, 500);

            Debug.WriteLine("event fired");
        }

    }
}
