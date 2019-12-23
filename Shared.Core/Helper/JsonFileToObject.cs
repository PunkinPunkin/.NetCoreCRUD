using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared.Helper
{
    public class JsonFileToObject<T> where T : class
    {
        public List<string> ErrorMsg { get; private set; }

        public T GetFileOject { get; private set; }

        public JsonFileToObject() { ErrorMsg = new List<string>(); }

        public async Task<bool> ReadAsync(string fileName)
        {
            return await ReadAsync(new FileInfo(fileName));
        }

        public async Task<bool> ReadAsync(FileInfo jsonFile)
        {
            ErrorMsg.Clear();
            if (!string.IsNullOrEmpty(jsonFile.FullName) && jsonFile.Exists)
                return await DeserializeAsync(jsonFile.FullName);
            else
                ErrorMsg.Add("FilePath is null or file does not exist.");

            return false;
        }

        private async Task<bool> DeserializeAsync(string fileName)
        {
            try
            {
                using (StreamReader tempFile = File.OpenText(fileName))
                {
                    GetFileOject = await JsonSerializer.DeserializeAsync<T>(tempFile.BaseStream);
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMsg.Add("Deserialize Error: " + ex.Message);
            }
            return false;
        }

        public async Task<bool> SerializeToFileAsync(string fileName, T obj)
        {
            try
            {
                using (FileStream fs = File.Create(fileName))
                {
                    await JsonSerializer.SerializeAsync(fs, obj);
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMsg.Add("Deserialize Error: " + ex.Message);
            }
            return false;
        }
    }
}
