package com.example;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class IndexServlet extends HttpServlet{
    private long visits = 0; // 存储访问次数
     @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        visits++; // 访问次数加1
        // 编写HTML代码
        String html = "<html>"
                + "<head>"
                + "</head>"
                + "<body>"
                + "<h1>Hello this is a html page!</h1>"
                + "<h1>Request Number:"+ visits +"</h1>"
                + "</body>"
                + "</html>";

        // 将HTML代码发送到客户端
        response.setContentType("text/html");
        response.getWriter().write(html);
    }
}
