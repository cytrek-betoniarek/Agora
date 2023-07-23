# Agora
REST API for Agora forum based on .NET 6

To create a SQLite database run the following command in the Agora.Api folder:
```
dotnet run seeddata
```
After the database is created, shut down the process creating it.
<br><br><br>
Admin login credentials: 
<ul>  
<li>login: admin@admin.admin</li>  
<li>password: Password1!</li>  
</ul>
<br>

While using swagger, after getting the token from the login endpoint it's necessary to enter it in the authorize section as follows:
```
bearer {token}
```
Please note that the token is supposed to be used without quotation marks.
<br><br><br>
An example of the expected date format is "01.01.2000".
<br><br>

## Dockerization

To create docker image run (on linux it may be necessary to precede following commands with "sudo"):
```
docker build --rm -t dist/agora-forum:latest .
```
To run image run:
```
docker run --rm -p 5000:5000 -p 5001:5001 -e ASPNETCORE_HTTP_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 dist/agora-forum:latest
```
Then swagger will be available at the following URL:
```
http://localhost:5000/swagger/index.html
```
