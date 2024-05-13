<%@ page language="java" import="java.util.*" contentType="text/html; charset=utf-8"%>
<%
String path = request.getContextPath();
String basePath = request.getScheme()+"://"+request.getServerName()+":"+request.getServerPort()+path+"/";
%>

<html>
  <head>
    <base href="<%=basePath%>">
    <!--
    <link rel="stylesheet" type="text/css" href="styles.css">
    -->

  </head>

  <body>
    <h1>request内置对象</h1><hr>

    <% 
    //解决页面显示中文乱码问题，无法解决URL传递中文出现的乱码问题
    request.setCharacterEncoding("utf-8");
    %>

         用户名：<%=request.getParameter("username") %><br/>

         密码：<%=request.getParameter("password") %><br/>

  </body>
</html>
