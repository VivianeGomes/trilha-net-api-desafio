using AutoMapper;
using TrilhaApiDesafio.Models;

public class MyProfile : Profile
{
    public MyProfile()
    {
        CreateMap<Tarefa, TarefaModel>(); // Mapeia a classe Tarefa para a classe TarefaModel
    }
}
