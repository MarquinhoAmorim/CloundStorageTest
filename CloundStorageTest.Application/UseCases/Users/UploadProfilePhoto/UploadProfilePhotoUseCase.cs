using CloundStorageTest.Domain.Entities;
using CloundStorageTest.Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace CloundStorageTest.Application.UseCases.Users.UploadProfilePhoto;
public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
{
    private readonly IStorageService _storageService;

    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public void Execute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();

        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();

        if (isImage == false)
            throw new Exception("The file is not an image.");

        var user = GetFromDatabase();

        _storageService.Upload(file, user);
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Amorim",
            Email = "amorimmarquinho65@gmail.com",
            RefreshToken = "1//04Y4ngP9XnvbfCgYIARAAGAQSNwF-L9IrF709EbKcxNVB85R6AlHSh2akZwFXcmZtYkOSVXtDHE_i2Sj8917UTHLSv7mkGZ6TxIc",
            AccessToken = "ya29.a0Ad52N39Div1XGGLWWVW2m76HIccHZnNXaMApMT94jwjGHYtB-YIz3Ei_2WELKCjpDjH-QCLQp6K1q-YLOOP_mmYsVuLHHroqLcom8Ild9xVHk2tSPE3GvjwbDhnnopCvzULybo3I8RkFSQDgmlsNe_ZVvD8mD0CG5wEFaCgYKARcSARMSFQHGX2MiyNadGCsITggk2aimNZ6Ogg0171"
        };
    }
}
