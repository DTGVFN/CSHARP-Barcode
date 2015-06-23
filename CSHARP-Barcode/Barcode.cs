using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CSHARP_Barcode
{
    class Barcode
    {

        

        public Barcode()
        {
           
        }



        public  Bitmap Create(int height ,int width,string x)
        {


            Bitmap MyCanvas = new Bitmap(height, width);  // Create Canvas Size wide 200 x 100 
            Graphics MyPen = Graphics.FromImage(MyCanvas);// Use Mypen draw to MyCanvas
            Rectangle MyArt = new Rectangle(0, 0, 200, 100); // Please see photo on Result.
            MyPen.FillRectangle(Brushes.White, MyArt);

            var DataCode39 = new Dictionary<string, string>();


            DataCode39["A"] = "110101001011";
            DataCode39["B"] = "101101001011";
            DataCode39["C"] = "110110100101";
            DataCode39["D"] = "101011001011";


            string YourText = x;
            string MyEncode = null;

            for (int x = 1; x <= YourText.Length; x++)
            {
                string charx = YourText.Substring(x - 1, 1);

                MyEncode = MyEncode + DataCode39[charx] + "0"; // 0 is Space bettewen char
            }
            MyEncode = "100101101101" + "0" + MyEncode + "100101101101";
            int CurserPoint = 0;
            int Location = 15;
            int xx = 1;
            for (int position = 1; position <= MyEncode.Length; position++)
            {
                string ch01 = MyEncode.Substring(position - 1, 1);
                CurserPoint = Location + 1;
                Rectangle Mybar = new Rectangle(Location, 0, 1, 100);
                if (ch01 == "0") MyPen.FillRectangle(Brushes.White, Mybar);
                else MyPen.FillRectangle(Brushes.Black, Mybar);
                xx++;
                Location = CurserPoint;
            }
          //  MyCanvas.Save("d:\\c39\\YourBarcodeFinal.jpg");

            return MyCanvas;
        }



    }
}

