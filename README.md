# EventsBackend
Для запуска нужен net6, visual studio 2022 (наверное можно установить net6 на visual studio 2019) и Microsoft SQL Server с локальной базой данных (localdb)\mssqllocaldb. 
Первым делом нужно назначить несколько запускаемых проектов - Identity и EventsWebApi. 
В консоли диспетчера пакетов для проекта Identity необходимо ввести 3 команды: 
    1)Update-Database -Context ApplicationDbContext 
    2)Update-Database -Context PersistedGrantDbContext 
    3)Update-Database -Context ConfigurationDbContext 
они так же прописаны в файле: Identity/Data/TextFile.txt 
Для выполнения команд в swagger нужно: в поле username ввести user в поле password ввести 123qwe 
После этого откроется доступ для выполнения команд.