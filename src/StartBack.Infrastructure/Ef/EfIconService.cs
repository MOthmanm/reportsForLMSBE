using StartBack.Application.Abstractions;
using StartBack.Application.DTOs;
using StartBack.Domain.Entities;
using StartBack.Infrastructure.Persistence.Repositories;
using StartBack.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace StartBack.Infrastructure.Ef;

public class EfIconService : IIconService
{
    private readonly IRepository<Icon> _icons;
    private readonly IUnitOfWork _uow;
    public EfIconService(IRepository<Icon> icons, IUnitOfWork uow)
    { _icons = icons; _uow = uow; }

    public IEnumerable<IconDto> GetAll() => _icons.Query().AsNoTracking().Select(Map).ToList();

    public IconDto? GetById(Guid id) => _icons.Query().AsNoTracking().Where(i => i.Id == id).Select(Map).FirstOrDefault();

    public IconDto Create(string key, string? displayName)
    {
        if (_icons.Query().Any(x => x.Key == key)) throw new InvalidOperationException("Icon key already exists");
        var i = new Icon { Key = key, DisplayName = displayName };
        _icons.AddAsync(i).GetAwaiter().GetResult();
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return Map(i);
    }

    public bool Update(Guid id, string key, string? displayName)
    {
        var i = _icons.Query().FirstOrDefault(x => x.Id == id);
        if (i == null) return false;
        if (_icons.Query().Any(x => x.Key == key && x.Id != id)) throw new InvalidOperationException("Icon key already exists");
        i.Key = key; i.DisplayName = displayName;
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    public bool Delete(Guid id)
    {
        var i = _icons.Query().FirstOrDefault(x => x.Id == id);
        if (i == null) return false;
        _icons.Remove(i);
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    private static IconDto Map(Icon i) => new(i.Id, i.Key, i.DisplayName);
}


