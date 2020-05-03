This is a simple console app targetting linux machine. In this sample, i'm trying to be familier with the framework.

RID(Runtime identifiers)
------------------------
https://docs.microsoft.com/en-us/dotnet/core/rid-catalog

# Publishing app for linux machine

`dotnet publish -c Release -r linux-x64`

# Running app from linux machine

before running the app, make sure the folder/file has execute permission

```bash
chmod 777 <file> 

dotnet path-to-file
```