using Microsoft.AspNetCore.Mvc;

namespace acme_back.Repositories;

public interface IRepository<T> where T : class
{
    Task<ActionResult<T>> GetById(int id);
    Task<ActionResult<List<T>>> GetAll();
    Task<ActionResult<T>> Add(T entity);
    Task<ActionResult<T>> Update(T entity);
    Task<ActionResult<T>> Delete(T entity);
}