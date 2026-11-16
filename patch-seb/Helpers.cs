using System.IO;

namespace patch_seb
{
	internal class Helpers
	{
		public static void PatchFile(string filePath, byte[] patchedFile)
		{
			File.Delete(filePath);
			File.WriteAllBytes(filePath, patchedFile);
		}
		public static void BackupFile(string filePath, string backupPath)
		{
			if (!File.Exists(backupPath))
			{
				File.Delete(backupPath);
			}
			File.Copy(filePath, backupPath, true);
		}
	}
}
