import os
if os.system("dotnet build --verbosity quiet owao/OWASDsharp.csproj") == 0:
    godot --export-debug "Windows Desktop" binares/OWASD-win.exe
    godot --export "Linux/X11" binares/OWASD-linux.x86_64
else:
    print("Bad")
