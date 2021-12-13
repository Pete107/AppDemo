<h1 align="center"><strong> Public demonstration</strong></h1>
<p>
This repository contains a basic setup of microservices (API's) with a range of front-end applications ranging from Blazor WASM, Windows WPF, Windows Forms and soon MAUI. (Once released)</p>

What has neem demonstrated is use of the following:
<ul>
<li>Authentication through the use of JWT Bearer tokens.</li>
<li>Basic front-end development. (not very strong on this end of things)</li>
<li>Dockerize of projects. (docker-compose)</li>
<li>Microservices (API's)</li>
<li>SOLID Principles.</li>
<li>Git Control.</li>
</ul>

<h3 align="center"><strong>To setup the project</strong></h3>
<p>
The Project requires MSSQL Server Database (unless you feel confortable changing it).
</p>
<p>
Docker compose contains an instance of an MSSQL Server Database which is ready to be configured and run, just provide a SQL User password in the docker-compose.yml file and fill the EnvironmentVariables in the overrides.yml.
</p>
<p>
Set the EnvironmentVariables in the <a href="https://dev.azure.com/Edens-Elite/PublicDemonstration/_git/MainDemo?path=/IdentityApi/Properties/launchSettings.json&version=GBmaster">launchSettings.json</a> file, 
notebly the <a href="https://dev.azure.com/Edens-Elite/PublicDemonstration/_git/MainDemo?path=/IdentityApi/Properties/launchSettings.json&version=GBmaster&line=20&lineEnd=21&lineStartColumn=1&lineEndColumn=1&lineStyle=plain&_a=contents">
lines 20~23</a>
</p>