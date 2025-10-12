using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using SHA256Web.Models;

namespace SHA256Web.Controllers
{
    public static class HashProgress
    {
        public static List<HashResult> Results { get; set; } = new List<HashResult>();
        public static int Percent { get; set; } = 0;
        public static bool Done { get; set; } = false;
    }

    [RoutePrefix("api/hash")]
    public class HashController : ApiController
    {
        [HttpPost]
        [Route("start")]
        public IHttpActionResult Start()
        {
            HashProgress.Results.Clear();
            HashProgress.Percent = 0;
            HashProgress.Done = false;

            var httpRequest = HttpContext.Current.Request;

            // 1️⃣ Jednotlivé soubory
            for (int i = 0; i < httpRequest.Files.Count; i++)
            {
                var file = httpRequest.Files[i];
                if (file != null && file.ContentLength > 0)
                {
                    string tempPath = SaveTempFile(file);
                    string hash = ComputeSHA256(tempPath);

                    HashProgress.Results.Add(new HashResult
                    {
                        CestaSouboru = tempPath,
                        Hash = hash
                    });
                }
            }

            // 2️⃣ Soubory ze složky (folderPicker)
            int j = 0;
            while (httpRequest.Files.AllKeys.Contains("folderFile" + j))
            {
                var file = httpRequest.Files["folderFile" + j];
                if (file != null && file.ContentLength > 0)
                {
                    string tempPath = SaveTempFile(file);
                    string hash = ComputeSHA256(tempPath);

                    HashProgress.Results.Add(new HashResult
                    {
                        CestaSouboru = tempPath,
                        Hash = hash
                    });
                }
                j++;
            }

            HashProgress.Percent = 100;
            HashProgress.Done = true;

            return Ok();
        }

        [HttpGet]
        [Route("progress")]
        public IHttpActionResult Progress()
        {
            var data = new
            {
                percent = HashProgress.Percent,
                done = HashProgress.Done,
                newRows = HashProgress.Results
            };
            return Ok(data);
        }

        [HttpGet]
        [Route("download")]
        public IHttpActionResult Download()
        {
            string fileName = "SHA256_Results.txt";
            string tempFile = Path.Combine(Path.GetTempPath(), fileName);

            using (StreamWriter writer = new StreamWriter(tempFile, false))
            {
                foreach (var r in HashProgress.Results)
                {
                    writer.WriteLine($"{r.CestaSouboru} | {r.Hash}");
                }
            }

            var response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
            var stream = new FileStream(tempFile, FileMode.Open, FileAccess.Read);
            response.Content = new System.Net.Http.StreamContent(stream);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");
            response.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };

            return ResponseMessage(response);
        }

        // 🔹 Bezpečné uložení souboru do TEMP
        private string SaveTempFile(HttpPostedFile file)
        {
            // odstranění neplatných znaků
            string safeFileName = string.Join("_", file.FileName.Split(Path.GetInvalidFileNameChars()));

            string tempPath = Path.Combine(Path.GetTempPath(), safeFileName);

            // vytvoření podsložek pokud chybí
            string dir = Path.GetDirectoryName(tempPath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            file.SaveAs(tempPath);

            return tempPath;
        }

        // 🔹 Výpočet SHA256
        private string ComputeSHA256(string filePath)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            using (var stream = File.OpenRead(filePath))
            {
                byte[] hashBytes = sha256.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
