using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadandWrite.cs
{
   public class FileWrite
    {
        public void write()
        {

            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter("C:\\Users\\Anaiyaan\\Desktop\\read.txt");

                writer.WriteLine("Using StreamWriter in code I am Writing this code into file");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                writer.Close();
            }


        }
    }
}
