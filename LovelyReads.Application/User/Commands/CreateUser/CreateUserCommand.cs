﻿using MediatR;

namespace LovelyReads.Application.User.Commands.CreateUser;

public class CreateUserCommand : IRequest<int>
{
    public string? Street { get;  set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? CPFNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? FullName { get; set; }
    public string? PasswordValue { get; set; }
}
