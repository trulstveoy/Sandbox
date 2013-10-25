<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ToastrSample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="content/toastr.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Look, it's a toaster greeting!!
    </div>
    </form>
    
    <script src="Scripts/jquery-1.6.4.js"></script>
    <script src="Scripts/toastr.js"></script>
    
    <script type="text/javascript">
        $(function() {
            
            toastr.options = {
                "debug": false,
                "positionClass": "toast-top-right",
                "onclick": null,
                "fadeIn": 300,
                "fadeOut": 1000,
                "timeOut": 5000,
                "extendedTimeOut": 1000
            };

            toastr.info('Are you the 6 fingered man?');
        });
    </script>
        
        

</body>
</html>
