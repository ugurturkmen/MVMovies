# MVMovies

Important Notes:

***in order to use caching, please download and unzip "redis_cache.rar" file. And then run executable exe file.

****in the project default database status is online. the project still connected to database online.
if you want to use locally, please download "MVMovies_Sql.sql" file and attaced to your local database. 
With name of database "MVMovies";





Project Notes:

In order to perform cache from Movie request I used Redis, 
and Cache Clear link is http://localhost:8869/api/CacheManagement/clear

I used Constructor Based Dependecy Injection tool for DI in MVMovies.
APIMovies and MVMovies.DataCache layers. 
I used it for having a Loosely Coupled and easy to developed Structure and reducing workload.

I used Cookie Authentication  for auth mechanism beceuse it is easy to use and easy to access.

In order to fix “10 minute data update issue” I used HostedService. 
HostedService is used for doing backend jobs in web and Api based projects. 
This issue can be fixed with also Windows Service, IIS Job, MsSql Job, but fixing with HostedService is better 
for project because of being easy to develop and update. 

If I had more time I will use repository and Unit Of Work pattern for this project.

I didnt develop .Net Core project until today, as I mentione in my CV I always developed ASP.Net MVC projects, 
thats why the project is a little bit beginner level, 
I tried to develeop the project as possibele as SOA compatible.
