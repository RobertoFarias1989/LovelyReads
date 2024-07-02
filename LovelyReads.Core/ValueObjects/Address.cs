namespace LovelyReads.Core.ValueObjects;

//aqui usamos o conceito de construtores primários
public record Address(string Street, string City, string State, string PostalCode, string Country);

