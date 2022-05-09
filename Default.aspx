<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestProject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<script type="text/javascript" charset="utf-8" src="/resources/js/jquery-1.12.4.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            // 데이터
            getData(1, 2020);
        });

        // 데이터 가져오기
        function getData(leId, seasonId) {
            var request = $.ajax({
                type: "post"
                , url: "/ws/Common.asmx/GetTest"
                , dataType: "json"
                , data: {
                    leId: leId
                    , seasonId: seasonId
                }
                , async: false
                , error: function (e) {
                    console.log(e);
                }
            });

            request.done(function (data) {
                console.log(data);
                console.log("1");
            });
        }
    </script>
</head>
<body>
        <div>
        </div>
</body>
</html>
