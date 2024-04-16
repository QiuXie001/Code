<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<jsp:directive.page import="java.util.List" />

<%

    List<com.model.Student> studentList = (List<com.model.Student>)request.getAttribute("studentList");
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>员工列表</title>
</head>
<body>
  <table border="1" width="75%">
  <tr><td colspan="9" align="center"><b>员工管理系统</b></tr>
  <tr><th>#</th><th>学号</th><th>姓名</th><th>性别</th><th>年龄</th><th>所在班级</th><th>手机号</th><th>住址</th><th>操作</th></tr>
  <% 
			out.println("<tr>");  
			   for(int col = 1;col<= studentList.size();col++){
          com.model.Student student = studentList.get(col-1);
          String sex = "";
          if(student.getSex() == 0)
          {
            sex = "男";
          }
          else
          {
            sex = "女";
          }
					 out.print("<td>" + col + "</td>"); 
           out.print("<td>" + student.getStuCode() + "</td>"); 
           out.print("<td>" + student.getStuName() + "</td>"); 
           out.print("<td>" + sex + "</td>"); 
           out.print("<td>" + student.getAge() + "</td>"); 
           out.print("<td>" + student.getBelongClassName() + "</td>"); 
           out.print("<td>" + student.getTelephone() + "</td>"); 
           out.print("<td>" + student.getAddress() + "</td>"); 
           out.println("<td><a href=\"demo/WorkManageServlet/update?id="+student.getStuCode()+"\">修改</a> <a href=\"demo/WorkManageServlet/delete?id="+student.getStuCode()+"\" onclick=\"return confirm('确定删除该学生吗')\">删除</a></td></tr>");
 		     }    
         out.println("<tr><td colspan=\"6\" align=\"center\"><a href=\"demo/WorkManageServlet/add\">添加员工</a> </td></tr>");     
     
		%>
  
  </table>
  
  
</body>
</html>