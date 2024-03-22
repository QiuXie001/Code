package com.example;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.util.Properties;

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
        request.setCharacterEncoding("UTF-8");
        // 设置响应代码
        response.setContentType("text/html;charset=UTF-8");
        String username = request.getParameter("username");
        String password = request.getParameter("password");
        request.setAttribute("username", username);
        request.setAttribute("password", password);
        // 将获取的数据封装成对象，存储在request对象中,request对象中可以存储任何数据类型（
        request.getRequestDispatcher("/Login.html").forward(request, response);

    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        // 获取表单提交的用户名和密码
        String username = request.getParameter("name");
        String password = request.getParameter("pwd");
        boolean check = false;
        // 加载配置文件
        Properties properties = new Properties();
        //ServletContext接口读取资源
        InputStream stream = this.getServletContext().getResourceAsStream("/resources/static/document/12021051010.properties");
        properties.load(new InputStreamReader(stream));

        // 获取配置文件中的值
        String UNameFrompProp = properties.getProperty("id");
        String PWDFromProp = properties.getProperty("password");
        System.out.println(UNameFrompProp + "/" + PWDFromProp);
        System.out.println(username + "/" + password);
        
        if (UNameFrompProp.equals(username) && PWDFromProp.equals(password)) {
            check = true;
        }

        if (check) {
            response.setContentType("text/html;charset=UTF-8");
            PrintWriter out = response.getWriter();
            out.println("<!DOCTYPE html><html><head><title>Login</title></head><body>");
            out.println("登陆成功！<br>");
            out.println("Username: " + username + "<br>");
            out.println("Password: " + password + "<br>");
            out.println("</body></html>");
            response.setHeader("Refresh", "5;URL=/demo/page.html");
        }
        else
        {
            response.setContentType("text/html;charset=UTF-8");
            PrintWriter out = response.getWriter();
            out.println("<!DOCTYPE html><html><head><title>Login</title></head><body>");
            out.println("登陆失败！<br>");
            out.println("检查用户名或密码后重试！");
            out.println("</body></html>");
            response.setHeader("Refresh", "5;URL=/demo/LoginServlet");
        }
    }
    
}
