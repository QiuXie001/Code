package com.example;

import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.util.Map;
import java.util.Properties;
import java.util.Set;

import javax.servlet.ServletConfig;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class ReadServlet extends HttpServlet {
    public String initStr;
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        PrintWriter writer = response.getWriter();
        writer.println(initStr);

        //配置<context-param>参数，然后利用ServletContext接口进行提取实现
        ServletContext context = this.getServletContext();
        String id = context.getInitParameter("id");
        String password = context.getInitParameter("password");
        System.out.println("form context id=" + id + ",password=" + password);
        writer.println("form context id=" + id + ",password=" + password);
        //ServletContext接口读取资源
        InputStream stream = this.getServletContext().getResourceAsStream("/resources/static/document/12021051010.properties");
        Properties pro = new Properties();

        pro.load(new InputStreamReader(stream));
        Set<Map.Entry<Object, Object>> set = pro.entrySet();
        for (Map.Entry<Object, Object> entry : set)
        {
            //输出到控制台和页面
            writer.print("form resource "+ entry.getKey() + "=" + entry.getValue());
            System.out.println("form resource "+ entry.getKey() + "=" + entry.getValue());
        }
        
    }
    @Override
    public void init(ServletConfig servletConfig) throws ServletException {
        super.init(servletConfig);

        //配置<init-param>参数，然后利用ServletConfig接口进行提取实现
        String id = servletConfig.getInitParameter("id"); // 获取指定的一个数据
        String password = servletConfig.getInitParameter("password");
        initStr = "form init id=" + id + ",password=" + password;
        System.out.println("form init id=" + id + ",password=" + password);
        

    }
}
