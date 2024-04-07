<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>员工列表</title>
</head>
<body>
  <table border="1" width="75%">
  <tr><td colspan="8" align="center"><b>学生管理系统</b></tr>
  <tr><th>#</th><th>学号</th><th>姓名</th><th>性别</th><th>年龄</th><th>出生日期</th><th>所在班级</th><th>操作</th></tr>
  <c:forEach items="${studentList}" var="curStudent" varStatus="status">
     <tr>
     <td>${status.count}</td>
     <td>${curStudent.stuCode}</td>
     <td>${curStudent.stuName}</td>
     <td>${(curStudent.sex==0)?'男':'女'}</td>
     <td>${curStudent.age}</td>
     <td>${curStudent.belongClassName}</td>
     <td><a href="${pageContext.request.contextPath}/StudentServlet/update?id=${curStudent.stuCode}">修改</a>
     <a href="${pageContext.request.contextPath}/StudentServlet/delete?id=${curStudent.stuCode}" onclick="return confirm('确定删除该学生吗')">删除</a></td>
     </tr>
  </c:forEach>
  <tr><td colspan="6" align="center"><a href="${pageContext.request.contextPath}/StudentServlet/add">添加员工</a> </td></tr>
  </table>
  
  
</body>
</html>