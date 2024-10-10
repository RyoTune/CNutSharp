using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CNutSharp.Library.Squirrel;

public class SqCompiler
{
    private readonly string _compilerPath;
    private readonly ILogger? _log;

    public SqCompiler(string compilerPath, ILogger? log = null)
    {
        if (!File.Exists(compilerPath))
        {
            throw new FileNotFoundException($"\"sq.exe\" was not found.\nFile: {compilerPath}");
        }

        _log = log;
        _compilerPath = compilerPath;
    }

    public bool Compile(string inputFile, string? outputFile = null)
    {
        try
        {
            outputFile ??= Path.ChangeExtension(inputFile, ".cnut");
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            var startInfo = GetStartInfo(inputFile, outputFile);
            var proc = Process.Start(startInfo);
            proc!.WaitForExit();

            var err = proc.StandardError.ReadToEnd();
            var info = proc.StandardOutput.ReadToEnd();
            if (proc.ExitCode != 0 || !File.Exists(outputFile))
            {
                _log?.LogError("Compilation likely failed.\nFile: {file}", inputFile);
                return false;
            }
        }
        catch (Exception ex)
        {
            _log?.LogError(ex, "Failed to compile file.\nFile: {file}", inputFile);
            return false;
        }

        return true;
    }

    private ProcessStartInfo GetStartInfo(string inputFile, string outputFile)
        => new($"\"{_compilerPath}\"", $"-o \"{outputFile}\" -c \"{inputFile}\"")
        {
            WorkingDirectory = Path.GetDirectoryName(outputFile),
            RedirectStandardError = true,
            RedirectStandardOutput = true,
        };
}
