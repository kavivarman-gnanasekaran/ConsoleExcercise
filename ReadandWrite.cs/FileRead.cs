using System;
using System.IO;

namespace ReadandWrite.cs
{
    public class FileReadandWrite
    {
     public void File()
        {

            String data;
            StreamReader reader = null;
            try
            {
                reader = new StreamReader("C:\\Users\\Anaiyaan\\Desktop\\read.txt");
                data = reader.ReadLine();

                while(data != null)
                {
                    Console.WriteLine(data);
                    data = reader.ReadLine();
                }
               
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

    }
}
