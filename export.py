import os
if os.system("dotnet build --verbosity quiet owao/OWASDsharp.csproj") == 0:
    os.system("cd owao && /home/ruzen42/Documents/Godot/Godot.x86_64 --export-debug \"windows\" binares/OWASD-win.exe")
    os.system("cd owao && /home/ruzen42/Documents/Godot/Godot.x86_64 --export-debug \"linux\" binares/OWASD-linux.x86_64")
else:
    print("Bad")
