<<<<<<< HEAD
using AutoMapper;
using DeviceService.Application.Features.DeviceType.Commands;
using DeviceService.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Type = DeviceService.Domain.Entities;

namespace DeviceService.Application.Features.DeviceType.Handlers.CommandHandlers;

public class CreateDeviceTypeCommandHandler(
    IDeviceTypeRepository deviceTypeRepository,
    IMapper mapper,
    IValidator<CreateDeviceTypeCommand> validator
) : IRequestHandler<CreateDeviceTypeCommand>
{
    private readonly IDeviceTypeRepository _deviceTypeRepository = deviceTypeRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateDeviceTypeCommand> _validator = validator;

    public async Task<Unit> Handle(
        CreateDeviceTypeCommand request,
        CancellationToken cancellationToken
    )
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken: cancellationToken);
        var deviceType = _mapper.Map<Type.DeviceType>(request);
        await _deviceTypeRepository.CreateAsync(deviceType);
        return Unit.Value;
    }
}
=======
using AutoMapper;
using DeviceService.Application.Features.DeviceType.Commands;
using DeviceService.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Type = DeviceService.Domain.Entities;

namespace DeviceService.Application.Features.DeviceType.Handlers.CommandHandlers;

public class CreateDeviceTypeCommandHandler(
    IDeviceTypeRepository deviceTypeRepository,
    IMapper mapper,
    IValidator<CreateDeviceTypeCommand> validator
) : IRequestHandler<CreateDeviceTypeCommand>
{
    private readonly IDeviceTypeRepository _deviceTypeRepository = deviceTypeRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateDeviceTypeCommand> _validator = validator;

    public async Task<Unit> Handle(
        CreateDeviceTypeCommand request,
        CancellationToken cancellationToken
    )
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken: cancellationToken);
        var deviceType = _mapper.Map<Type.DeviceType>(request);
        await _deviceTypeRepository.CreateAsync(deviceType);
        return Unit.Value;
    }
}
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
