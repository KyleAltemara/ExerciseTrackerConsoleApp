namespace ExerciseTrackerConsoleApp.Repositories;

using ExerciseTrackerConsoleApp.Data;
using Microsoft.EntityFrameworkCore;

public class RunningTrackerRepository<T> : IRepository<T> where T : RunningEntry
{
    private readonly ExerciseTrackerContext _context;
    private readonly DbSet<T> _dbSet;

    public RunningTrackerRepository(ExerciseTrackerContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public T? GetById(int id) => _dbSet.Find(id);

    public IEnumerable<T> GetAll() => [.. _dbSet];

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
}
