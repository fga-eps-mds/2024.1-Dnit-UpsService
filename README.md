# UpsService

Serviço responsável pelas funcionalidades relacionadas à 
gerência de sinistros, de rodovias e cálculo de UPS de escolas.

## Pré requisitos

- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Docker e [Docker Compose](https://docs.docker.com/compose/install/)

Se você tem o Compose instalado como standalone, use:

```sh
docker-compose ...
```

Entretando, prefira instalar o Docker Compose como plugin (recomedação do 
Docker). Os comandos nesse formato são assim:

```sh
docker compose ...
```

Se você precisa de `sudo` para executar comandos do Docker, consulte o 
[guia](https://docs.docker.com/engine/install/linux-postinstall/) de pós-instalação.

## Executar

```sh
git clone https://github.com/fga-eps-mds/2024.1-Dnit-UpsService.git
cd 2024.1-Dnit-UpsService
```

**NOTA**: lembre-se de criar a rede pelo UsuarioService: [banco-de-dados.md](https://github.com/fga-eps-mds/2023.2-Dnit-UsuarioService/blob/main/docs/banco-de-dados.md).

Inicie todos os containeres:

```sh
docker compose up -d
```

Ou iniciar apenas o container de banco de dados, entrar no diretório `app/` 
e iniciar o servidor nativamente:

```sh
docker compose up -d dnit-escola-db
cd app
dotnet watch
```

Acesse a documentação da API pelo swagger em http://localhost:7085/swagger.

### Banco de dados e rede docker

Para mais informações sobre como acessar o banco de dados, leia o guia 
[banco-de-dados.md](https://github.com/fga-eps-mds/2023.2-Dnit-UsuarioService/blob/main/docs/banco-de-dados.md)
no repositório `UsuarioService`.

### Editor

Para mais informações sobre instalação e IDE, leia o guia.
[ambiente.md](https://github.com/fga-eps-mds/2023.2-Dnit-UsuarioService/blob/main/docs/ambiente.md)
no repositório `UsuarioService`.

## Licença

O projeto UpsService está sob as regras aplicadas na licença 
[AGPL-3.0](https://github.com/fga-eps-mds/2023.2-Dnit-UpsService/blob/main/LICENSE).
