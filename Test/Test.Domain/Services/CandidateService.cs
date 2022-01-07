using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Interfaces;
using Test.Domain.Validations;
using Test.Domain.ViewModel;

namespace Test.Domain.Services
{
    public class CandidateService : IGenericService<Candidate>
    {
        private readonly IAsyncRepository<Candidate> _repository;

        public CandidateService(IAsyncRepository<Candidate> repository)
        {
            _repository = repository;
        }

        public async Task<Result> AddAsync(Candidate entity)
        {
            var result = new Result();
            try
            {
                if (await AnyAsync(entity.Identification))
                    return new Result() { message = "Ya existe el numero de Identificación", _return = true };

                await _repository.AddAsync(entity);
                result.message = "Se ha registrado con exito.";
                result.result = entity;
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.result = true; 
            }
            return result;
        }

        public async Task<Result> DeleteAsync(object Id)
        {
            var result = new Result();
            try
            {
                var entity = await _repository.GetByIdAsync(Id);
                await _repository.DeleteAsync(entity);
                result.message = "Se ha eliminado con exito.";
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.result = true;
            }
            return result;
        }

        public async Task<Result> GetAllAsync()
        {
            var result = new Result();
            try
            {
                result.result = await _repository.ListAllAsync();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.result = true;
            }
            return result;
        }

        public async Task<Result> GetAsync(object Id)
        {
            var result = new Result();
            try
            {
                result.result = await _repository.GetByIdAsync(Id);
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.result = true;
            }
            return result;
        }

        public async Task<Result> UpdateAsync(Candidate entity)
        {
            var result = new Result();
            try
            {
                await _repository.UpdateAsync(entity);
                result.message = "Se ha actualizado con exito.";
                result.result = entity;
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.result = true;
            }
            return result;
        }

        public async Task<Result> Search(string value)
        {
            var result = new Result();
            try
            {
                var entities = await _repository.ListAllAsync();
                result.result = entities.Where(w => w.Name.Contains(value)
                || w.LastName.Contains(value)
                || w.Identification.ToString().Contains(value)
                || w.Age.ToString().Contains(value))
                    .ToList();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.result = true;
            }
            return result;
        }

        async Task<bool> AnyAsync(int identification) => await _repository.AnyExpressionAsync(a=> a.Identification == identification);
    }
}
