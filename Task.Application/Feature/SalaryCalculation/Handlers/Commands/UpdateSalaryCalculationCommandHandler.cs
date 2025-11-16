using AutoMapper;
using MediatR;
using Task.Application.Common;
using Task.Application.Contracts;
using Task.Application.Feature.SalaryCalculation.Requests.Commands;
using Task.Shared.DTOs.SalaryCalculation;
using Task.Shared.Utilities;

namespace Task.Application.Feature.SalaryCalculation.Handlers.Commands
{
    public class UpdateSalaryCalculationCommandHandler : IRequestHandler<UpdateSalaryCalculationCommandRequest, SalaryCalculationDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataParser _dataParser;
        private readonly IMapper _mapper;

        public UpdateSalaryCalculationCommandHandler(IUnitOfWork unitOfWork, IDataParser dataParser, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _dataParser = dataParser;
            _mapper = mapper;
        }

        public async Task<SalaryCalculationDto> Handle(UpdateSalaryCalculationCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SalariesCalculation.GetAsync(request.Id);
            if (entity == null)
                return null;

            var dtos = await _dataParser.ParseAsync<CreateSalaryCalculationDto>(request.Datatype, request.Data);
            if (!dtos.Any())
                throw new Exception("No data to process");

            var dto = dtos.First();

            decimal overTime = request.OverTimeCalculator switch
            {
                "CalculatorA" => OvetimePolicies.CalculatorA(dto.BasicSalary, dto.Allowance) - (dto.BasicSalary + dto.Allowance),
                "CalculatorB" => OvetimePolicies.CalculatorB(dto.BasicSalary, dto.Allowance) - (dto.BasicSalary + dto.Allowance),
                "CalculatorC" => OvetimePolicies.CalculatorC(dto.BasicSalary, dto.Allowance) - (dto.BasicSalary + dto.Allowance),
                _ => 0
            };

            _mapper.Map(dto, entity);
            entity.OverTime = overTime;
            entity.FinalSalary = dto.BasicSalary + dto.Allowance + dto.Transportation + overTime;

            await _unitOfWork.SaveChangesAsync();

            var resultDto = _mapper.Map<SalaryCalculationDto>(entity);
            return resultDto;
        }
    }
}
