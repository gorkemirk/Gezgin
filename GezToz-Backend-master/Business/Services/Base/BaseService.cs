﻿using Business.Services.Base.Interface;
using Business.Utilities.Mapping.Interface;
using Core.Constants;
using Core.Results;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;


namespace Business.Services.Base;

public abstract class BaseService<TEntity, TId, TResponseDto> : IBaseService<TEntity, TId, TResponseDto>
    where TEntity : class
    where TResponseDto : class
{
    protected readonly IMapperHelper _mapperHelper;
    private readonly IRepository<TEntity, TId> _repository;
    protected readonly IUnitOfWork _unitOfWork;

    public BaseService(IUnitOfWork unitOfWork, IRepository<TEntity, TId> repository, IMapperHelper mapperHelper)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _mapperHelper = mapperHelper;
    }

    public virtual async Task<DataResult<TResponseDto>> GetByIdAsync(TId id)
    {
        TEntity entity = await _repository.GetByIdAsync(id);
        TResponseDto responseDto = _mapperHelper.Map<TResponseDto>(entity);
        return new DataResult<TResponseDto>(responseDto);
    }

    public virtual async Task<DataResult<IList<TResponseDto>>> GetAllAsync()
    {
        IList<TEntity> entities = await _repository.GetAllAsync();
        IList<TResponseDto> mappedEntities = _mapperHelper.Map<IList<TResponseDto>>(entities);
        return new DataResult<IList<TResponseDto>>(mappedEntities);
    }

    public virtual async Task<Result> AddAsync(TEntity entity)
    {
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return new Result(Messages.SuccessfullyCreatedEntity, ResultStatus.Ok);
    }

    public virtual async Task<Result> AddFromDtoAsync(object entityDto)
    {
        TEntity entity = _mapperHelper.Map<TEntity>(entityDto);
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return new Result(Messages.SuccessfullyCreatedEntity, ResultStatus.Ok);
    }

    public virtual async Task<Result> UpdateAsync(TId id, object entityDTO)
    {
        TEntity entity = await _repository.GetByIdAsync(id);

        _mapperHelper.Map(entityDTO, entity);
        _repository.Update(entity);
        await _unitOfWork.CommitAsync();
        return new Result(Messages.SuccessfullyUpdatedEntity, ResultStatus.Ok);
    }

    public virtual async Task<Result> DeleteAsync(TId id)
    {
        await _repository.RemoveByIdAsync(id);
        await _unitOfWork.CommitAsync();
        return new Result(Messages.SuccessfullyDeletedEntity, ResultStatus.Ok);
    }
}