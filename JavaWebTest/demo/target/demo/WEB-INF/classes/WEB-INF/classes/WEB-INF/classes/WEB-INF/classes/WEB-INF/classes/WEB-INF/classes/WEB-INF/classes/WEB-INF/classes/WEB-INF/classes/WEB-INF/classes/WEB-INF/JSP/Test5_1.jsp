<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<table border="1">
		<% 
		 for(int row=1;row<=9;row++){
			   out.println("<tr>");  
			   for(int col=1;col<= row;col++){
					 out.print("<td>");    
					 out.print(row+ "*"+ col + "=" + row*col );
					 out.print("</td>");
			   }   
			   out.println("</tr>");
		 } 
		%>
	  </table>	 
</body>
</html>
