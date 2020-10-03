Ol�, foi e esta sendo um grande aprendizado esse desafio.
Nesse projeto criei um Blazor Server Side e uma  API usando .Net Core 3.1 e estou utilizando o MySQL como persist�ncia, pois anteriormente eu estava usando SQL SERVER do pr�prio Visual Studio, e n�o estava sendo muito perfom�tico na hora de debugar e fazer as requis�es.
Para iniciar a solution, precisam preparar o ambiente do MYSQL, criei um banco que se chama "SensorHub" com apenas uma tabela que se chama "Sensores", nela foi inseridos as colunas "tag", "timestamp" e "valor".O campo chave "id" � gerado automaticamento a cada novo item salvo.
De inicio eu criei  um projeto Web usando Hangfire para criar meus objetos de forma automatica para simular a chegada de eventos, mas depois de perder o projeto todo por ter feito um revert errado refiz como um Blazor Server Side  meu para aprendizado. Al�m disso na arquitetura da aplica��o foi aplicado o DDD e pr�ncipios do S.O.L.I.D

###Tecnologias abordadas foram :#### 

AutoMapper,
Blazor WebAssembly,
MySQL,
API REST .NET CORE

###Tetar API###
http://localhost:50620/api/sensores

###Formas de uso :#####

Para criar um novo evento o Json tem que estar neste formato por exemplo :

{
     
    "timestamp":"01/01/2020" <-- desse formato pois no meu service tem uma regra de neg�cio para fazer a convers�o em UNIX
    "tag":"brasil.regiao.sensor"
    "valor": pode ser nulo
}

###O que faltou ?#####

###N�o consegui fazer a tabela em RealTime usando SignalR

##N�o consegui rodar a aplica��o usando Docker pois esta dando erro de Socket e n�o consegui resolver, por�m o mesmo ja est� instalado.



######Considera��es finais:######
Muito obrigado pela oportunidade de fazer esse desafio foi um grande aprendizado para mim nesse tempo e tamb�m pe�o mil perd�es por n�o ter enviado no dia combinado, pois estou em tempo de entrega de projetos  na faculdade e acabou coincidindo junto com o desafio, desde j� o meu muito obrigado pela oportunidade!
