using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Results.AboutResults;
using Application.Interfaces;
using Application.Interfaces.AboutInterfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutOneQueryHandler
    {
        private readonly IAboutRepository _repository;
        public GetAboutOneQueryHandler(IAboutRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutOneQueryResult> Handle()
        {
            var value = await _repository.GetFirstOrDefault();
            var result = new GetAboutOneQueryResult
            {
                AboutId = value.AboutId,
                AboutTitle = value.AboutTitle,
                AboutDescription = value.AboutDescription,
                AboutImage = value.AboutImage
            };
            return result;
        }
    }
}