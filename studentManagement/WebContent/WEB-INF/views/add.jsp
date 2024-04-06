<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>  
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<%--函数库 --%>
<%@ taglib prefix="fn" uri="http://java.sun.com/jsp/jstl/functions" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
</head>
<body>
   <br><br><h1 align="center">学生添加页面</h1>
   <form action="StudentServlet/add" method="post">
   <table align="center" >
   <tr><td>学号</td><td><input type="text" name="stuCode"></td></tr>
   <tr><td>姓名</td><td><input type="text" name="stuName"></td></tr>
   <tr><td>年龄</td><td><input type="text" name="age"></td></tr>
   <tr><td>性别</td><td><input type="radio" name="sex" value="0">男 &nbsp;&nbsp;<input type="radio" name="sex" value="1">女</td></tr>
   <tr><td>出生日期</td><td><input type="date" name="birthday"><font color="red"> 格式：1990-01-01</font></td></tr>
   <tr><td>所在班级</td><td>
   <select name="curClassId">
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