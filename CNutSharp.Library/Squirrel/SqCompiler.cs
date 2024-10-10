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

    /// <summary>
    /// Compiles a NUT file. If no output path is passed,
    /// the compiled CNUT will placed next to the input file.
    /// </summary>
    /// <param name="inputFile">Input NUT file.</param>
    /// <param name="outputFile">Optional output CNUT file.</param>
    /// <returns>Whether compilation succeeded.</returns>
    public async Task<bool> TryCompile(string inputFile, string? outputFile = null)
    {
        try
        {
            outputFile ??= Path.ChangeExtension(inputFile, ".cnut");
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            var startInfo = GetStartInfo(inputFile, outputFile);
            var proc = Process.Start(startInfo) ?? throw new Exception("Failed to start compiler.");
            await proc.WaitForExitAsync();

            var err = proc.StandardError.ReadToEnd();
            if (proc.ExitCode != 0 || !File.Exists(outputFile))
            {
                _log?.LogError("Failed to compile file.\n{error}\nFile: {inputFile}", err, inputFile);
                return false;
            }
        }
        catch (Exception ex)
        {
            _log?.LogError(ex, "Failed to compile file.\nFile: {inputFile}", inputFile);
            return false;
        }

        return true;
    }

    private ProcessStartInfo GetStartInfo(string inputFile, string outputFile)
        => new($"\"{_compilerPath}\"", $"-o \"{outputFile}\" -c \"{inputFile}\"")
        {
            WorkingDirectory = Path.GetDirectoryName(outputFile),
            RedirectStandardError = true,
        };
}
