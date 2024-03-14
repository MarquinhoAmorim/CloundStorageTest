using CloundStorageTest.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CloundStorageTest.Domain.Storage;
public interface IStorageService
{
    string Upload(IFormFile file, User user);
}
