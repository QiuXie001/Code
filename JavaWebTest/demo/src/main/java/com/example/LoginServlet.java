package com.example;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@WebServlet("/LoginServlet")
public class LoginServlet extends HttpServlet{
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
                response.setContentType("text/html;charset=UTF-8");
        request.setCharacterEncoding("UTF-8");
        String html = "<form action=\"/demo/LoginServlet\" method=\"post\">"
                + "userName:<input type=\"text\" name=\"name\"/><br>"
                + "password:<input type=\"password\" name=\"pwd\"/><br>"
                + "<input type=\"submit\" value=\"Login\"/></form>";
        response.getWriter().println(html);
        
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        // 获取表单提交的用户名和密码
        String username = request.getParameter("name");
        String password = request.getParameter("pwd");

        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        out.println("<!DOCTYPE html><html><head><title>Login</title></head><body>");
        out.println("登陆成功！<br>");
        out.println("Username: " + username + "<br>");
        out.println("Password: " + password + "<br>");
        out.println("</body></html>");
        
        
        response.setHeader("Refresh", "5;URL=/demo/page.html");
    }
    
}
