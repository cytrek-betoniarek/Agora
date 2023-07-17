# Agora
REST API for Agora forum based on .NET 6

To create a SQLite database run the following command in the Agora.Api folder:
```
dotnet run seeddata
```
<br>
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
Please note that the token is supposed to be used without quotation marks
<br><br><br>
An example of the expected date format is "01.01.2000"
