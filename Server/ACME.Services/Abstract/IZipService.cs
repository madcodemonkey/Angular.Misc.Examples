﻿using System.IO;

namespace ACME.Services
{
    public interface IZipService
    {
        MemoryStream CreateZipStreamForOneFile(MemoryStream inputFileStream, string inputFileName, bool leaveOpen = false);
    }
}