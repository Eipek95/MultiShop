﻿using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands
{
    public class CreateAddressCommand : IRequest
    {
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
