using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace RealtimeNasm
{
    /// <summary>
    /// Работи с nasm.exe
    /// </summary>
    public abstract class Nasm
    {
        private static string pathToExe;

        private static int fileSaveRatio = 10;
        private static int fileCounter = 1;

        public static bool LoadPath()
        {
            try
            {
                pathToExe = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\nasmpath.txt");
            }
            catch (Exception e)
            {
                return false;
            }
            return true; // може да се сложи и проверка за правилен път
        }

        public static NasmOutput Assemble(string asmString)
        {
            string filename = MakeFilename();
            File.WriteAllText(filename + ".asm", asmString);

            Process process = new Process();
            process.StartInfo.Arguments = string.Format("-s -f bin {0}.asm", filename);
            process.StartInfo.FileName = pathToExe;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            var outStream = process.StandardOutput;
            process.WaitForExit();

            NasmOutput result = new NasmOutput();
            result.stdOut = outStream.ReadToEnd();
            try
            {
                result.assembledBytes = File.ReadAllBytes(filename);

                if (fileCounter != fileSaveRatio)
                {
                    File.Delete(filename);
                    File.Delete(filename + ".asm");
                }
                else fileCounter = 1;
                fileCounter++;
            }
            catch (Exception e)
            {
                if (result.stdOut == "") result.stdOut = "error";
                File.Delete(filename + ".asm");
            }

            return result;
        }

        private static string MakeFilename()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "\\asm_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
        }
    }
}
