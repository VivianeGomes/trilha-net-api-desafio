# DIO - Trilha .NET - API e Entity Framework
<www.dio.me>

## Desafio de projeto

Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de API e Entity Framework, da trilha .NET da DIO.

## Contexto

Você precisa construir um sistema gerenciador de tarefas, onde você poderá cadastrar uma lista de tarefas que permitirá organizar melhor a sua rotina.

Essa lista de tarefas precisa ter um CRUD, ou seja, deverá permitir a você obter os registros, criar, salvar e deletar esses registros.

A sua aplicação deverá ser do tipo Web API ou MVC, fique a vontade para implementar a solução que achar mais adequado.

A sua classe principal, a classe de tarefa, deve ser a seguinte:

![Diagrama da classe Tarefa](diagrama.png)

Não se esqueça de gerar a sua migration para atualização no banco de dados.

## Métodos esperados

É esperado que você crie o seus métodos conforme a seguir:

**Swagger**

![Métodos Swagger](swagger.png)

**Endpoints**

| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| GET    | /Tarefa/{id}            | id        | N/A           |
| PUT    | /Tarefa/{id}            | id        | Schema Tarefa |
| DELETE | /Tarefa/{id}            | id        | N/A           |
| GET    | /Tarefa/ObterTodos      | N/A       | N/A           |
| GET    | /Tarefa/ObterPorTitulo  | titulo    | N/A           |
| GET    | /Tarefa/ObterPorData    | data      | N/A           |
| GET    | /Tarefa/ObterPorStatus  | status    | N/A           |
| POST   | /Tarefa                 | N/A       | Schema Tarefa |

Esse é o schema (model) de Tarefa, utilizado para passar para os métodos que exigirem

```json
{
  "id": 0,
  "titulo": "string",
  "descricao": "string",
  "data": "2022-06-08T01:31:07.056Z",
  "status": "Pendente"
}
```

## Solução

O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.


# Configuração do AutoMapper e Banco de Dados em Memória

Este guia descreve como configurar o AutoMapper e criar/executar um banco de dados em memória em um aplicativo ASP.NET Core.

## Configuração do AutoMapper

1. **Crie um perfil de mapeamento**:

```csharp
using AutoMapper;
using TrilhaApiDesafio.Models;

public class MyProfile : Profile
{
    public MyProfile()
    {
        CreateMap<Tarefa, TarefaModel>(); // Mapeia a classe Tarefa para a classe TarefaModel
    }
}
```

2. **Registre o perfil de mapeamento no Startup.cs**:

```csharp
// Dentro do método ConfigureServices em Startup.cs
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MyProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
services.AddSingleton(mapper);
```

3. **Uso do AutoMapper em um controlador**:

```csharp
using AutoMapper;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

public class TarefaController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly OrganizadorContext _context;

    public TarefaController(IMapper mapper, OrganizadorContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult Criar(TarefaModel tarefaModel)
    {
        var tarefa = _mapper.Map<Tarefa>(tarefaModel);
        // Restante do código...
    }
}
```

## Criação e Execução do Banco de Dados em Memória

1. **Adicione o serviço de banco de dados em memória no Startup.cs**:

```csharp
// Dentro do método ConfigureServices em Startup.cs
services.AddDbContext<OrganizadorContext>(options => options.UseInMemoryDatabase("OrganizadorDB"));
```

2. **Uso do banco de dados em memória em um controlador**:

```csharp
using TrilhaApiDesafio.Context;

public class TarefaController : ControllerBase
{
    private readonly OrganizadorContext _context;

    public TarefaController(OrganizadorContext context)
    {
        _context = context;
    }

    // Métodos que utilizam o contexto do banco de dados em memória...
}
```

3. **Executando o aplicativo com banco de dados em memória**:

    - Execute seu aplicativo normalmente. O banco de dados em memória será criado e usado durante a execução do aplicativo.

Com essas configurações, você poderá utilizar o AutoMapper para mapear objetos entre suas entidades e modelos DTO, bem como criar e utilizar um banco de dados em memória em seu aplicativo ASP.NET Core.

```

Este guia fornece uma visão geral dos passos necessários para configurar o AutoMapper e usar um banco de dados em memória em um aplicativo ASP.NET Core, juntamente com exemplos de código em C#. Certifique-se de adaptar essas instruções conforme necessário para o seu próprio aplicativo.
