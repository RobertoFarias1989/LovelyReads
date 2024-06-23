﻿namespace LovelyReads.Core.ValueObjects;

public record CPF
{
    public CPF(string cPFNumber)
    {
        CPFNumber = cPFNumber;
    }

    public string CPFNumber { get; init; }
}
