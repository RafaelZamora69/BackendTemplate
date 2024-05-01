using Application.Abstractions.Responses;
using MediatR;

namespace Application.Abstractions.Commands;

public record BaseCommand<T> : IRequest<Response<T>> { }