# Golden Raspberry Awards API

## Descrição

Este projeto implementa uma API RESTful para leitura e consulta da lista de indicados e vencedores da categoria "Pior Filme" do Golden Raspberry Awards. A API permite identificar o produtor com o maior intervalo entre dois prêmios consecutivos e o produtor que obteve dois prêmios mais rapidamente.

## Funcionalidades

- Carregar dados de um arquivo CSV ao iniciar a aplicação.
- Consultar:
  - O produtor com o maior intervalo entre dois prêmios consecutivos.
  - O produtor com o menor intervalo entre dois prêmios consecutivos.
- API compatível com o nível 2 do modelo de maturidade de Richardson.
- Banco de dados em memória (EF Core In-Memory).
- Testes de integração para validação dos endpoints.

## Tecnologias Utilizadas

- .NET 8
- EF Core In-Memory
- XUnit para testes de integração
- Swagger para documentação da API

## Como Executar o Projeto com Docker

```
git clone https://github.com/packetspy/outsera-golden-raspberry-awards.git`
cd outsera-golden-raspberry-awards
cd solution
docker-compose up -d
```

### Acesse a API na URL padrão:

http://localhost:5051/swagger

## Como Executar o Projeto em linha de comando

### Pré-requisitos

- .NET SDK 8+ instalado.

### Passos para Rodar a API

Clone o repositório:

```
git clone https://github.com/packetspy/outsera-golden-raspberry-awards.git
cd outsera-golden-raspberry-awards
cd solution
```

### Compile o projeto:

`dotnet build`

### Rode a aplicação:

`dotnet run --project GoldenRaspberryAward.Api`

### Acesse a API na URL padrão:

http://localhost:5172/swagger

### Como Executar os Testes

1 - Navegue até o diretório do projeto:
`cd GoldenRaspberryAward.Tests`

2 - Execute os testes:
`dotnet test`

## Endpoints da API

Obter Intervalos de Prêmios

`GET /api/movies/intervals`

Resposta

```json
{
  "min": {
    "producer": "Producer B",
    "interval": 1,
    "previousWin": 1990,
    "followingWin": 1991
  },
  "max": {
    "producer": "Producer A",
    "interval": 10,
    "previousWin": 2000,
    "followingWin": 2010
  }
}
```
