using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Gammes.Commands.CreateGamme;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, CreateSupplierCommandResponse>
    {
        public readonly IAsyncRepository<Supplier> _supplierRepository;
        public readonly IMapper _mapper;

        public CreateSupplierCommandHandler(IAsyncRepository<Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<CreateSupplierCommandResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var createSupplierResponse = new CreateSupplierCommandResponse();
            var createSupplierValidator = new CreateSupplierCommandValidator();

            var resultSupplierValidator = await createSupplierValidator.ValidateAsync(request);

            if (resultSupplierValidator.Errors.Count > 0)
            {
                createSupplierResponse.Success = false;
                createSupplierResponse.ValidationErrors = new List<string>();

                foreach (var errors in resultSupplierValidator.Errors)
                {
                    createSupplierResponse.ValidationErrors.Add(errors.ErrorMessage);
                }
            }

            if (createSupplierResponse.Success)
            {
                var supplier = new Supplier()
                {
                    Name = request.Name,
                };

                supplier = await _supplierRepository.AddAsync(supplier);

                createSupplierResponse.SupplierDto = _mapper.Map<SupplierDto>(supplier);
            }

            return createSupplierResponse;
        }
    }
}
