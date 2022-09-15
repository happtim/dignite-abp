﻿using System;
using System.IO;
using Dignite.Abp.Files.Fakes;
using Dignite.Abp.Files.TestObjects;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.IO;
using Volo.Abp.Modularity;
using Dignite.Abp.BlobStoring;
using Microsoft.Extensions.Options;

namespace Dignite.Abp.Files;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpFilesDomainModule),
    typeof(AbpBlobStoringFileSystemModule)
    )]
public class AbpFilesDomainTestModule : AbpModule
{
    private readonly string _testDirectoryPath;

    public AbpFilesDomainTestModule()
    {
        _testDirectoryPath = Path.Combine(
            Path.GetTempPath(),
            Guid.NewGuid().ToString("N")
        );
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBlobStoringOptions>(options =>
        {

            options.Containers
                .Configure<TestContainer2>(container =>
                {
                    container.UseFileSystem(fileSystem =>
                    {
                        fileSystem.BasePath = _testDirectoryPath;
                    });
                    container.AddBlobSizeLimitHandler(config =>
                       config.MaximumBlobSize = 1
                    );
                })
                .Configure<TestContainer3>(container =>
                {
                    container.UseFileSystem(fileSystem =>
                    {
                        fileSystem.BasePath = _testDirectoryPath;
                    });
                    container.AddFileTypeCheckHandler(config =>
                       config.AllowedFileTypeNames = new string[] { ".jpeg" }
                    );
                })
                .Configure<TestContainer4>(container =>
                {
                    container.UseFileSystem(fileSystem =>
                    {
                        fileSystem.BasePath = _testDirectoryPath;
                    });
                    container.AddImageResizeHandler(imageResize =>
                    {
                        imageResize.ImageWidth = 200;
                        imageResize.ImageHeight = 200;
                        imageResize.ImageSizeMustBeLargerThanPreset = false;
                    });
                });
        });
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context)
    {
        DirectoryHelper.DeleteIfExists(_testDirectoryPath, true);
    }
}
