namespace LovelyReads.Core.Entities;

public abstract class BaseEntity
{
    //a classe é criada com o modificador de acesso abstract para que assim não seja possível instanciá-la

    //construtor vazio para uso do EF Core quando for rodar as migrations
    public BaseEntity()
    {

    }

    //usamos o protected para que assim seja possível acessar estas propriedades das classes derivadas
    public int Id { get; protected set; }
    public bool IsActive { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    public virtual void Inactived()
    {
        IsActive = false;
    }
}
