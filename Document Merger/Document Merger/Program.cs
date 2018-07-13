using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Document Merger");
            Console.WriteLine();

            String file1 = "";
            String fileName1 = "";
            String file2 = "";
            String fileName2 = "";
            String merge = "";

            do
            {
                Console.WriteLine("Enter the name of the first text file: ");
                fileName1 = Console.ReadLine();
                file1 = fileName1 + ".txt";

                while (File.Exists(file1) == false)
                {
                    Console.WriteLine("File does not exist.");
                    Console.WriteLine("Please re-enter Document name: ");
                    file1 = Console.ReadLine();
                }

                Console.WriteLine("Enter the name of the second text file: ");
                fileName2 = Console.ReadLine();
                file2 = fileName2 + ".txt";

                while (File.Exists(file2) == false)
                {
                    Console.WriteLine("File does not exist.");
                    Console.WriteLine("Please re-enter Document name: ");
                    file2 = Console.ReadLine();
                }

                merge = fileName1 + fileName2 + ".txt";

                StreamWriter write = null;
                StreamReader readFile1 = null;
                StreamReader readFile2 = null;

                String line1 = "";
                String line2 = "";
                String mergedLine = "";

                int charCount = 0;

                try
                {

                    while ((line1 = readFile1.ReadLine()) != null)
                    {
                        charCount += line1.Length;
                        mergedLine += readFile1;
                    }

                    while ((line2 = readFile2.ReadLine()) != null)
                    {
                        charCount += line2.Length;
                        mergedLine += readFile2;
                    }

                    write.WriteLine(mergedLine);
                    Console.WriteLine(merge + " was successfully saved. The document contains " + charCount + " characters.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (write != null)
                    {
                        write.Close();
                    }

                    if (readFile1 != null)
                    {
                        readFile1.Close();
                    }

                    if (readFile2 != null)
                    {
                        readFile2.Close();
                    }
                }

                Console.WriteLine("Would you like to merge two more files? (yes/no): ");

                string check = "";
                check = Console.ReadLine();

                if (check == "no")
                {
                    break;
                }
            }
            while (true);

        }
    }
}
