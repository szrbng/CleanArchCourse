﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchCourse.Application.Interfaces.UnitOfWorks;
using CleanArchCourse.Domain.Concrete.Entities;
using MediatR;

namespace CleanArchCourse.Application.Features.CategorySubOperetions.Commands.CreateCategorySub
{
    public class CreateCategorySubCommand : IRequestHandler<CreateCategorySubRequest,CreateCategorySubResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategorySubCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateCategorySubResponse> Handle(CreateCategorySubRequest request, CancellationToken cancellationToken)
        {

            var categorySub = _mapper.Map<CategorySub>(request);
            categorySub.IsDeleted = false;

            await _unitOfWork.CategorySub.Add(categorySub);
            await _unitOfWork.SaveChanges();
            return new CreateCategorySubResponse { Message = "Category Sub had been added." };
        }
    }
}
