<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/functions" 
    prefix="fn" %> 
<%@ page isELIgnored="false" %>
<jsp:directive.page import="java.util.List" />
<head>
<head>
    <meta charset="utf-8">
    <title>修改页面</title>
</head>
<body>
    <form action="WorkManage/update" method="post">
     <table align="center" >
   <tr><td>学号</td><td><input type="text" name="stuCode" pattern="^(?!\s*$).*" required></td></tr>
   <tr><td>姓名</td><td><input type="text" name="stuName" pattern="^(?!\s*$).*" required></td></tr>
   <tr><td>年龄</td><td><input type="text" name="age" pattern="^(?!\s*$).*" required></td></tr>
   <tr><td>性别</td><td><input type="radio" name="sex" value="0" pattern="^(?!\s*$).*" required>男 &nbsp;&nbsp;<input type="radio" name="sex" value="1">女</td></tr>
   <tr><td>手机号</td><td><input type="text" name="telephone" pattern="^1[3-9]\d{9}$" required></td></tr>
   <tr><td>住址</td><td><input type="text" name="address" pattern="^(?!\s*$).*" required></td></tr>
   <tr><td>所在班级</td><td>
   <select name="curClassId" required>
     <c:forEach items="${blongClass}" var="curClass">
      <option value="${curClass.classId}" ${fn:contains(param['curClass.classId'],curClass.classId)?'selected':'' }>${curClass.className}</option>
     </c:forEach>
     </select>
   </td></tr>
   <tr ><td colspan="2"><input type="submit" value="保存"></td><td colspan="2"> <input type="reset" value="重置"></td></tr>
   </table> 
   </form>
</body>
</html>
