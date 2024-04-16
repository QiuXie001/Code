<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" session="true" %>


<form action="/demo/LoginServlet" method="post">
    用户名:<input type="text" name="name" value="<%=session.getAttribute("username")%>" /><br>
    密码:<input type="password" name="pwd" value="<%=session.getAttribute("password")%>" /><br>
    记住密码：<input type="checkbox" id="rememberPassword" name="rememberPassword"><br>
    <input type="submit" value="Login"/>
  </form>
