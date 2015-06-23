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



        public  Bitmap Create(int height ,int width,string textconvert)
        {


            Bitmap MyCanvas = new Bitmap(height, width);  // Create Canvas Size wide 200 x 100 
            Graphics MyPen = Graphics.FromImage(MyCanvas);// Use Mypen draw to MyCanvas
            Rectangle MyArt = new Rectangle(0, 0, height, width); // Please see photo on Result.
            MyPen.FillRectangle(Brushes.White, MyArt);

            var DataCode39 = new Dictionary<string, string>();


            DataCode39["0"] = "101001101101";
            DataCode39["1"] = "110100101011";
            DataCode39["2"] = "101100101011";
            DataCode39["3"] = "110110010101";
            DataCode39["4"] = "101001101011";
            DataCode39["5"] = "110100110101";
            DataCode39["6"] = "101100110101";
            DataCode39["7"] = "101001011011";
            DataCode39["8"] = "110100101101";
            DataCode39["9"] = "101100101101";
            DataCode39["A"] = "110101001011";
            DataCode39["B"] = "101101001011";
            DataCode39["C"] = "110110100101";
            DataCode39["D"] = "101011001011";
            DataCode39["E"] = "110101100101";
            DataCode39["F"] = "101101100101";
            DataCode39["G"] = "101010011011";
            DataCode39["H"] = "110101001101";
            DataCode39["I"] = "101101001101";
            DataCode39["J"] = "101011001101";
            DataCode39["K"] = "110101010011";
            DataCode39["L"] = "101101010011";
            DataCode39["M"] = "110110101001";
            DataCode39["N"] = "101011010011";
            DataCode39["O"] = "110101101001";
            DataCode39["P"] = "101101101001";
            DataCode39["Q"] = "101010110011";
            DataCode39["R"] = "110101011001";
            DataCode39["S"] = "101101011001";
            DataCode39["T"] = "101011011001";
            DataCode39["U"] = "110010101011";
            DataCode39["V"] = "100110101011";
            DataCode39["W"] = "110011010101";
            DataCode39["X"] = "100101101011";
            DataCode39["Y"] = "110010110101";
            DataCode39["Z"] = "100110110101";
            DataCode39["-"] = "100101011011";
            DataCode39["."] = "110010101101";
            DataCode39[" "] = "100110101101";
            DataCode39["$"] = "100100100101";
            DataCode39["/"] = "100100101001";
            DataCode39["+"] = "100101001001";
            DataCode39["%"] = "101001001001";
            DataCode39["*"] = "100101101101";


            string YourText = textconvert.ToUpper();
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
                Rectangle Mybar = new Rectangle(Location, 0, 1, width);
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

