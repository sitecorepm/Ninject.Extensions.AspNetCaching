<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Sample.Website.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Sample</h1>
        <p>
            This page retrieves "Grades" from a business logic layer. The Sample.BusinessLogicLayer.Student
            class has been configured with the Caching Intercept layer by:
        </p>
        <ol>
            <li>Adding the "[CacheAllVirtualMethods(DefaultTimeoutMinutes = 1)]" class attribute</li>
            <li>Ensuring the methods you want to cache are <i>virtual</i></li>
        </ol>
        <asp:GridView ID="gvGrades" runat="server">
        </asp:GridView>

        <p>This sample result overrides the cache timeout for a particular method in the class: Sample.BusinessLogicLayer.Student.GetGradesWithHigherCacheTimeout </p>
        <asp:GridView ID="gvGradesLongerCache" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
