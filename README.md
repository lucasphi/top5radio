# top5radio

## Arquitetura
![Architectural design](https://raw.githubusercontent.com/lucasphi/top5radio/master/top5radio.png)

## Decisões tomadas
- Foram utilizados "Mocks" nos bancos de dados. Para efeitos de uma aplicação real, um banco em um servidor externo seria utilizado.
- Rode "dotnet stryker" no console, na pasta de testes para rodar os testes de mutação.
- Para aplicações maiores, as camadas deveriam ser separadas em projetos diferentes.
