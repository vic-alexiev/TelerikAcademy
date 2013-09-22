<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="KendoFileUpload.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/kendo.common.min.css" rel="stylesheet" />
    <link href="styles/kendo.default.min.css" rel="stylesheet" />
    <script src="scripts/jquery.min.js"></script>
    <script src="scripts/kendo.web.min.js"></script>
</head>
<body>
    <input name="uploaded" id="uploaded" type="file" runat="server" />

    <script>
        $(document).ready(function () {
            $("#uploaded").kendoUpload({
                async: {
                    saveUrl: "Upload",
                    removeUrl: "Remove",
                    autoUpload: true
                },
                upload: onUpload
            });
        });

        function onUpload(e) {
            // Array with information about the uploaded files
            var files = e.files;

            // Check the extension of each file and abort the upload if it is not .jpg
            $.each(files, function () {
                if (this.extension != ".zip") {
                    alert("This file type is not supported. Only .zip files can be uploaded.")
                    e.preventDefault();
                    return false;
                }
            });
        }
    </script>
</body>
</html>
