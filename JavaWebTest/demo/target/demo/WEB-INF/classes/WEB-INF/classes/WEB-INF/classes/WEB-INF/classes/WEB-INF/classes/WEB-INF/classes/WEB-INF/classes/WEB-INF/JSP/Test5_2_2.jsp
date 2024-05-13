<%@ page language="java" import="java.util.*" contentType="text/html; charset=utf-8"%>

<%
String path = request.getContextPath();
String basePath = request.getScheme()+"://"+request.getServerName()+":"+request.getServerPort()+path+"/";
%>

<html>
  <head>
    <base href="<%=basePath%>">

  </head>

  <body>
    <h1>用户注册</h1> <hr>
    <form name="regForm" action="JspForward" method="post">
        <table>
            <tr>
                <td>用户名：</td>
                <td><input type="text" name="username"/></td>
            </tr>
            <tr>
                
                <td>密码：</td>
                <td><input type="text" name="password"/></td>
            </tr>
            <tr>
                <td colspan="2"><input type="submit" name="submitBnt" value="submit"/></td>
            </tr>
        </table>
    </form>
  </body>
</html>
