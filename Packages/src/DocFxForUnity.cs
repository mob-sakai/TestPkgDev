using System;
using System.IO;
using System.Xml.Linq;
using Packages.Rider.Editor;
using UnityEditor;

namespace Coffee
{
    /// <summary>
    /// Setup csproj files for DocFx on CI environment.
    /// `-executeMethod Coffee.DocFxForUnity.SetupCsProj`
    /// </summary>
    public static class DocFxForUnity
    {
        private const string k_DstDir = "Library/DocFxAssemblies";

#if DOCFX_DEBUG
    [MenuItem("Development/Coffee.DocFxForUnity.SetupCsProj")]
#endif
        public static void SetupCsProj()
        {
            Console.WriteLine($"[Coffee.DocFxForUnity.SetupCsProj]");

            // Generate solution and project file.
            Console.WriteLine($"  -> Generate solution and project files (RiderScriptEditor)");
            RiderScriptEditor.SyncSolution();

            // Delete local old dlls.
            Console.WriteLine($"  -> Delete local old dlls");
            if (Directory.Exists(k_DstDir))
            {
                Directory.Delete(k_DstDir, true);
            }

            Directory.CreateDirectory(k_DstDir);

            // Copy dlls to local.
            foreach (var csprojPath in Directory.GetFiles(".", "*.csproj"))
            {
                CopyDllsForCsProj(csprojPath);
            }
        }

        private static void CopyDllsForCsProj(string csprojPath)
        {
            Console.WriteLine($"  -> Copy dlls for: {csprojPath}");
            var xml = XDocument.Load(csprojPath);
            foreach (var e in xml.Descendants())
            {
                // Already copied -> skip.
                if (e.Name.LocalName != "HintPath" || e.Value.StartsWith(k_DstDir)) continue;

                // Copy dlls.
                var src = e.Value;
                var dst = $"{k_DstDir}/{Path.GetFileName(src)}";

                // Copy dll files.
                CopyFile(src, dst);

                // Copy xml files.
                CopyFile(Path.ChangeExtension(src, ".xml"), Path.ChangeExtension(dst, ".xml"));

                // Change HintPath value.
                e.Value = dst;
            }

            xml.Save(csprojPath);
        }

        private static void CopyFile(string src, string dst)
        {
            if (!File.Exists(src) || File.Exists(dst)) return;

            Console.WriteLine($"    - {Path.GetFileName(dst)}");
            File.Copy(src, dst);
        }
    }
}
