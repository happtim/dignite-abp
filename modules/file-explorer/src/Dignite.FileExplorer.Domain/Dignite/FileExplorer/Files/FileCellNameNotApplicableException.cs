﻿using System.Runtime.Serialization;
using Volo.Abp;

namespace Dignite.FileExplorer.Files;
public class FileCellNameNotApplicableException : BusinessException
{
    public FileCellNameNotApplicableException()
    {
        Code = FileExplorerErrorCodes.Files.CellNameNotApplicable;
    }

    public FileCellNameNotApplicableException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
    {
        Code = FileExplorerErrorCodes.Files.CellNameNotApplicable;
    }
}