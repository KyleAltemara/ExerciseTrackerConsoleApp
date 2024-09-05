namespace ExerciseTrackerConsoleApp.Repositories;

/// <summary>
/// Represents a generic repository interface.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Gets an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>The entity with the specified ID, or null if not found.</returns>
    T? GetById(int id);

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>An enumerable collection of entities.</returns>
    IEnumerable<T> GetAll();

    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void Add(T entity);

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(T entity);

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(T entity);
}
