using Microsoft.AspNetCore.Http;

namespace CloundStorageTest.Application.UseCases.Users.UploadProfilePhoto;
public interface IUploadProfilePhotoUseCase
{
    public void Execute(IFormFile file);
}
