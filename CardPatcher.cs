using System;
using System.Collections.Generic;
using System.IO;
using BepInEx;
using Mono.Cecil;

namespace KayceeCardnamePatch
{
    static class CardPatcher
    {

        internal static BepInEx.Logging.ManualLogSource Logger =
            BepInEx.Logging.Logger.CreateLogSource("KayceeCardnamePatch");

        public static IEnumerable<string> TargetDlls { get; } = new string[] { };

        public static void Patch(AssemblyDefinition assemblyDefinition)
        {
            Logger.LogError($"How did you even end up here? Here's the definition: {assemblyDefinition.FullName}");
        }

        public static void Finish()
        {
            Logger.LogInfo($"Fetching card files");

            var cardFiles = new List<string>(Directory.GetFiles(Paths.PluginPath, "*.jldr", SearchOption.AllDirectories));

            var cardFilesFiltered = cardFiles.FindAll(f => !f.EndsWith("_card.jldr"));

            Logger.LogMessage($"Found {cardFiles.Count} cards of which {cardFilesFiltered.Count} are not patched yet");

            foreach (var cardFile in cardFilesFiltered)
            {
                try
                {
                    Logger.LogInfo($"Patching {Path.GetFileName(cardFile)} to {Path.GetFileNameWithoutExtension(cardFile)}_card.jldr");
                    File.Move(cardFile, cardFile.Replace(".jldr", "_card.jldr"));
                }
                catch (Exception e)
                {
                    Logger.LogError($"Error on: {cardFile}");
                    Logger.LogError(e);
                }
            }
        }
    }
}
