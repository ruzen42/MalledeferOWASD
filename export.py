import os
if os.system("dotnet build --verbosity quiet owao/OWASDsharp.csproj") == 0:
    godot3 --export "windows" binares/OWASD-win.exe
    godot3 --export "linux" binares/OWASD-linux.x86_64
else:
    print("Bad")
