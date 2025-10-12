<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hash.aspx.cs" Inherits="SHA256Web.Hash" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>SHA256 Výpočet</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Výpočet SHA256</h2>

        <label>Vyber soubory:</label><br />
        <input type="file" id="files" multiple /><br /><br />

        <label>Vyber složku:</label><br />
        <input type="file" id="folderPicker" webkitdirectory directory multiple style="display:none;" />
        <input type="text" id="folder" placeholder="Zvol složku..." size="40" readonly />
        <button type="button" id="btnBrowse">Procházet</button>
        <br /><br />

        <button type="button" onclick="startHash()">Spustit</button>
        <button type="button" onclick="download()">Uložit TXT</button>
        <button type="button" id="btnReset">Obnovit</button>

        <br /><br />
        <progress id="progressBar" value="0" max="100" style="width:300px;"></progress>
        <p id="progressText"></p>

        <table border="1" id="resultsTable">
            <tr><th>Soubor (včetně cesty)</th><th>SHA256</th></tr>
        </table>

        <script>
            function startHash() {
                var files = $('#files')[0].files;
                var folderFiles = $('#folderPicker')[0].files;
                var formData = new FormData();

                for (var i = 0; i < files.length; i++) {
                    formData.append('file' + i, files[i]);
                }
                for (var j = 0; j < folderFiles.length; j++) {
                    formData.append('folderFile' + j, folderFiles[j]);
                }

                $.ajax({
                    url: '/api/hash/start',
                    type: 'POST',
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function () {
                        updateProgress();
                    }
                });
            }

            function updateProgress() {
                $.getJSON('/api/hash/progress', function (data) {
                    $('#progressBar').val(data.percent);
                    $('#progressText').text(data.percent + '% hotovo');

                    for (var i = 0; i < data.newRows.length; i++) {
                        var r = data.newRows[i];
                        $('#resultsTable').append('<tr><td>' + r.CestaSouboru + '</td><td>' + r.Hash + '</td></tr>');
                    }

                    if (!data.done) {
                        setTimeout(updateProgress, 1000);
                    }
                });
            }

            function download() {
                window.location = '/api/hash/download';
            }

            $('#btnReset').click(function () {
                $('#resultsTable tr:not(:first)').remove();
                $('#progressBar').val(0);
                $('#progressText').text('');
                $('#files').val('');
                $('#folder').val('');
                $('#folderPicker').val('');
            });

            $('#btnBrowse').click(function () {
                $('#folderPicker').click();
            });

            $('#folderPicker').change(function () {
                if (this.files.length > 0) {
                    var fullPath = this.files[0].webkitRelativePath;
                    var folderName = fullPath.split('/')[0];
                    $('#folder').val(folderName);
                }
            });
        </script>
    </form>
</body>
</html>
