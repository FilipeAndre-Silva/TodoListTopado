namespace TodoListTopado.Domain.Enums
{
    public enum TaskItemEnum
    {
        NotStarted = 0, // Tarefa ainda não começou
        InProgress = 1, // Tarefa em andamento
        OnHold = 4,     // Tarefa pausada
        Completed = 3,  // Tarefa concluída
        Cancelled = 5   // Tarefa cancelada
    }
}