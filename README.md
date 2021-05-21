## Sobre o projeto
É uma arquitetura que utiliza padrões e boas práticas, criada para auxiliar a escrita de código com alta qualidade, minimizando a geração de bugs - e necessidade de manutenções futuras - e aumentando a produtividade das equipes em todos os níveis.

Possui um frontend criado apenas para fins demonstrativos.

## CRUD de exemplo
Esta arquitetura possui um cadastro completo de produtos como exemplo de código, inclusive com a aplicação de regras de negócio e controle de níveis de acesso, entre outras coisas.

## Padrões utilizados
- DDD - Domain Driven Design
- SOLID (Single Responsability, Open Close, Liskov Substitution, Interface Segregation and Dependency Invertion)
- Repository
- Facade
- Specification
- Inversion of control
- Dependency injection
- CodeFirst
- Outros

## Ferramentas utilizadas
- ASP.Net MVC 5
- Entity Framework 6
- SimpleInjector 4
- AutoMapper 4
- DomainValidation 1
- Dapper 2
- Outras

## Camada crosscuting
- Identity desacoplado - Qualquer projeto pode realizar autenticação e autorização compartilhando o mesmo código para este fim
- Dependency Injection com SimpleInjector em uma camada específica
- MVC Filters utilizados da maneira correta

## Colaboradores
[**Alexandre Freitas**](https://www.linkedin.com/in/alexandredsfreitas)
