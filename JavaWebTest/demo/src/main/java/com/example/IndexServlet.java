package com.example;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class IndexServlet extends HttpServlet{
    private long visits = 0; // �洢���ʴ���
     @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        visits++; // ���ʴ�����1
        // ��дHTML����
        String html = "<html>"
                + "<head>"
                + "</head>"
                + "<body>"
                + "<h1>Hello this is a html page!</h1>"
                + "<h1>Request Number:"+ visits +"</h1>"
                + "</body>"
                + "</html>";

        // ��HTML���뷢�͵��ͻ���
        response.setContentType("text/html");
        response.getWriter().write(html);
    }
}
