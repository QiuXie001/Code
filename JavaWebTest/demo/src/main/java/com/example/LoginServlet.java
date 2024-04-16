package com.example;

import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.util.Properties;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

@WebServlet("/LoginServlet")
public class LoginServlet extends HttpServlet {
    boolean SuccessLogin = true;
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        Cookie[] cookies;
        HttpSession session = request.getSession();
        if(SuccessLogin)
        {
            cookies = request.getCookies();
        }
        else cookies = null;
        if (cookies != null) {
            for (Cookie cookie : cookies) {
                
                if (cookie.getName().equals("username")) {
                    String username = cookie.getValue();
                    session.setAttribute("username", username);
                }
                if (cookie.getName().equals("password")) {
                    String password = cookie.getValue();
                    session.setAttribute("password", password);
                }
            }
            
        }
        request.setCharacterEncoding("UTF-8");
        // 设置响应代码
        response.setContentType("text/html;charset=UTF-8");
        String username = request.getParameter("username");
        String password = request.getParameter("password");
        request.setAttribute("username", username);
        request.setAttribute("password", password);
        // 将获取的数据封装成对象，存储在request对象中,request对象中可以存储任何数据类型（
        request.getRequestDispatcher("/Login.jsp").forward(request, response);
        
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        String username;
        String password;
        boolean LoginCheck = false;
        boolean rememberPassword = false;
            // 获取表单提交的用户名和密码
        username = request.getParameter("name");
        password = request.getParameter("pwd");
        rememberPassword = request.getParameter("rememberPassword") != null;
        

        // 加载配置文件
        Properties properties = new Properties();
        // ServletContext接口读取资源
        InputStream stream = this.getServletContext()
                .getResourceAsStream("/resources/static/document/12021051010.properties");
        properties.load(new InputStreamReader(stream));

        // 获取配置文件中的值//xiexin//12021051010
        String UNameFrompProp = properties.getProperty("id");
        String PWDFromProp = properties.getProperty("password");
        // System.out.println(UNameFrompProp + "/" + PWDFromProp);
        // System.out.println(username + "/" + password);

        if (UNameFrompProp.equals(username) && PWDFromProp.equals(password)) {
            LoginCheck = true;
            SuccessLogin = true;
            if (rememberPassword) {
                Cookie usernameCookie = new Cookie("username", username);
                Cookie passwordCookie = new Cookie("password", password);
                usernameCookie.setMaxAge(60 * 60 * 24); // 设置cookies有效期为一天
                passwordCookie.setMaxAge(60 * 60 * 24);
                response.addCookie(usernameCookie);
                response.addCookie(passwordCookie);
            }
            else
            {
                HttpSession session = request.getSession();
                session.setAttribute("username","");
                session.setAttribute("password","");
                Cookie usernameCookie = new Cookie("username", "");
                Cookie passwordCookie = new Cookie("password", "");
                usernameCookie.setMaxAge(0); // 设置cookie的最大生存时间为0，即立即过期
                passwordCookie.setMaxAge(60 * 60 * 24);
                response.addCookie(usernameCookie);
                response.addCookie(passwordCookie);
            }
        }

        if (LoginCheck) {
            response.setContentType("text/html;charset=UTF-8");
            PrintWriter out = response.getWriter();
            out.println("<!DOCTYPE html><html><head><title>Login</title></head><body>");
            out.println("登陆成功！<br>");
            out.println("Username: " + username + "<br>");
            out.println("Password: " + password + "<br>");
            out.println("</body></html>");
            response.setHeader("Refresh", "5;URL=/demo/WorkManage/shows");
        } 
        else 
        {
            HttpSession session = request.getSession();
            session.setAttribute("username","");
            session.setAttribute("password","");
            Cookie usernameCookie = new Cookie("username", "");
            usernameCookie.setMaxAge(0); // 设置cookie的最大生存时间为0，即立即过期
            usernameCookie.setPath("/"); // 设置cookie的路径，使整个网站都能访问到这个cookie
            response.addCookie(usernameCookie);
            SuccessLogin = false;
            Cookie passwordCookie = new Cookie("password", "");
            passwordCookie.setMaxAge(0);
            passwordCookie.setPath("/");
            response.addCookie(passwordCookie);

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
