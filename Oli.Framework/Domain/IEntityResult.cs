namespace Oli.Framework.Domain
{
    public interface IEntityResult<TEntity, out TKey> : IEntity<TKey>
    {
    }
}