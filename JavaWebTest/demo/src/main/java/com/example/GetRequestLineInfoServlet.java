package com.example;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class GetRequestLineInfoServlet extends HttpServlet{
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        // 获取请求方式
        String Method = request.getMethod();
        // 获取URI
        String uri = request.getRequestURI();
        // 获取URL
        StringBuffer url = request.getRequestURL();
        // 获取客户端IP
        String clientIp = request.getRemoteAddr();
        // 获取服务端IP
        String serverIp = request.getLocalAddr();
        // 获取服务器端端口
        int serverPort = request.getLocalPort();
        // 获取字符集编码
        String characterEncoding = request.getCharacterEncoding();

         // 使用StringBuilder代替StringBuffer
         StringBuilder sb = new StringBuilder();
         sb.append("</br>请求方式: ").append(Method);
         sb.append("</br>URI: ").append(uri);
         sb.append("</br>URL: ").append(url);
         sb.append("</br>客户端IP: ").append(clientIp);
         sb.append("</br>服务端IP: ").append(serverIp);
         sb.append("</br>服务器端端口: ").append(serverPort);
         sb.append("</br>字符集编码: ").append(characterEncoding);
 
         // 打印输出所有信息
         response.setContentType("text/html;charset=UTF-8");
         PrintWriter out = response.getWriter();
         out.println(sb.toString());
         out.close();
    }
}
